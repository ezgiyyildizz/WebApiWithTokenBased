using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiWithTokenBased.Helpers
{
    public class TokenManager
    {
        private readonly string _jwtSecretKey;

        public TokenManager(string jwtSecretKey)
        {
            _jwtSecretKey = jwtSecretKey;
        }

        public string GenerateAccessToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(string username)
        {
            // Burada refresh token'ları şifrelemek için gerekli işlemleri gerçekleştirin
            // Örnek olarak, RNGCryptoServiceProvider ve Convert.ToBase64String gibi yöntemler kullanılabilir
            // Şifreleme işlemi tamamlandıktan sonra şifrelenmiş refresh token'ı döndürün
            // Örnek olarak return Convert.ToBase64String(encryptedRefreshToken);
            // Şu anlık basitlik için şifreleme adımlarını atlayarak random bir değer döndürüyoruz.

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

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
                    ValidateIssuer = false, // You might want to change these to match your requirements
                    ValidateAudience = false // You might want to change these to match your requirements
                };

                // Validate the token and extract the claims from it
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return null;
            }
            catch (Exception)
            {
                // Some other error occurred
                return null;
            }
        }

    }
}
