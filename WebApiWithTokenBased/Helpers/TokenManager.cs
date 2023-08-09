using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiWithTokenBased.Helpers
{
    public class TokenManager
    {
        private readonly string _jwtSecretKey;
        private readonly IConfiguration _configuration;

        public TokenManager(string jwtSecretKey, IConfiguration configuration)
        {
            _jwtSecretKey = jwtSecretKey;
            _configuration = configuration;
        }

        // Access token oluşturma
        public string GenerateAccessToken(string username, string email, string phoneNumber)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

            var jwtsettings = _configuration.GetSection("Jwt");


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.MobilePhone, phoneNumber),
                }),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtsettings["AccessTokenExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



        // Refresh token oluşturma
        public string GenerateRefreshToken(string username, string email, string phoneNumber)
        {
            // Şifreleme işlemleri 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
            var jwtsettings = _configuration.GetSection("Jwt");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.MobilePhone, phoneNumber), 
                }),

                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtsettings["AccessTokenExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }




        // Token'ın geçerliliğini doğrulama
        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenRead = tokenHandler.ReadJwtToken(token);

            var expTime = tokenRead.ValidTo;

            DateTime convertedExpTime = DateTime.SpecifyKind(
                    expTime,
                    DateTimeKind.Utc);

            var kind = expTime.Kind;

            return DateTime.Now < expTime.ToLocalTime();
        }

        // Token'dan ClaimsPrincipal alma işlemi
        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false 
                };

                // Token'ı doğrulama ve içindeki verileri alma
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (SecurityTokenException)
            {
                // Token doğrulaması başarısız 
                return null;
            }
            catch (Exception)
            {
                // Diğer hatalar 
                return null;
            }
        }

    }
}
