using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiWithTokenBased.Helpers;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.ActionFilters
{
    // Token tabanlı kimlik doğrulama işlemini gerçekleştiren bir action filter.
    // Web API istekleri geldiğinde bu filtre istekteki Authorization header'ından gelen token'ı doğrular,
    // Eğer token geçerli değilse, isteği yetkilendirme hatasıyla sonlandırır (401 Unauthorized).
    public class TokenAuthenticationFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly ILogger<TokenAuthenticationFilter> _logger;
        private readonly TokenManager tokenManager;
        private readonly UserManager<UserCredentials> userManager;
        private readonly RoleManager<UserRole> roleManager;
        private readonly string policy;



        // Yapıcı metot
        // ILogger<TokenAuthenticationFilter> parametresi, filter'ın kullanacağı logger örneğini alır,
        // TokenManager parametresi, token'ın geçerliliğini doğrulamak için kullanılacak TokenManager sınıfıdır.
        public TokenAuthenticationFilter(ILogger<TokenAuthenticationFilter> logger, TokenManager tokenManager, RoleManager<UserRole> roleManager, UserManager<UserCredentials> userManager, string policy = null)
        {
            _logger = logger;
            this.tokenManager = tokenManager;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.policy = policy;
        }

        // OnActionExecuting metodu, action metodu çalıştırılmadan önce otomatik olarak çağrılır,
        // Bu metot, token'ın geçerliliğini doğrular ve istek eğer geçerli değilse yetkilendirme hatasıyla sonlandırır.
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // İstekten gelen token'ı al
            var token = context.HttpContext.Request.Headers["Authorization"].ToString()?.Replace("Bearer ", "");

            // Token'ın geçerli olup olmadığını doğrula
            if (string.IsNullOrEmpty(token) || !tokenManager.ValidateToken(token))
            {
                _logger.LogInformation("Geçersiz token.");

                // Özelleştirilmiş hata durumu döndür
                context.Result = new JsonResult(new { error = "Geçersiz token." })
                {
                    StatusCode = 401 // 401 Unauthorized durumu
                };

                return;
            }

            var principal = tokenManager.GetPrincipalFromToken(token);

            if (string.IsNullOrEmpty(policy))
            {
                context.HttpContext.User = principal;
                return;
            }


            if (principal is null)
                throw new Exception("Kullanıcı bulunamadı.");

            //context.HttpContext.User = principal;
            //_logger.LogInformation("Token doğrulandı.");


            var user = await userManager.FindByNameAsync(principal.Identity.Name);
            var roles = await userManager.GetRolesAsync(user);

            foreach (var r in roles)
            {
                var userRole = await roleManager.FindByNameAsync(r);
                var claims = await roleManager.GetClaimsAsync(userRole);

                foreach (var claim in claims)
                {
                    if (claim.Type.Equals(policy))
                    {
                        // Eğer bu kullanıcı ve rolde belirli bir yetkilendirme (claim) varsa,
                        // kullanıcının kimliği (principal) HttpContext.User olarak ayarlanır.
                        context.HttpContext.User = principal;
                        return; // Yetkilendirme bulunduğunda işlem sonlanır
                    }
                }
            }



            // Kullanıcının gerekli rollerden hiçbirine sahip olmaması durumunda istek yasaklanır
            context.Result = new ForbidResult();
            return;
        }
    }
}
