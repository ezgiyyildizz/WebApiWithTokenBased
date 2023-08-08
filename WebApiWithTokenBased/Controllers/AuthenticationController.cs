using Microsoft.AspNetCore.Mvc;
using WebApiWithTokenBased.Dto;

//Web API'nin denetleyicisi

namespace WebApiWithTokenBased.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticationController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        // POST api/Authentication/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationDto registrationDto)
        {
            // Kullanıcı kaydını yap
            var tokenDictionary = await _authRepository.Register(registrationDto);

            if (tokenDictionary != null)
            {
                // Kullanıcı başarıyla kaydedildiyse access token ve refresh token'ları döndür
                var accessTokenDto = new AccessTokenDto
                {
                    AccessToken = tokenDictionary["accessToken"],
                    RefreshToken = tokenDictionary["refreshToken"]
                };

                return Ok(accessTokenDto);
            }

            return BadRequest("Kullanıcı kaydı başarısız.");
        }

        // POST api/Authentication/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // Kullanıcı adı ve parola ile giriş yapmayı doğrula
            bool isLoginSuccessful = await _authRepository.Login(loginDto);

            if (isLoginSuccessful)
            {
                // Giriş başarılıysa access token ve refresh token'ları döndür
                var accessTokenDto = new AccessTokenDto
                {
                    AccessToken = _authRepository.GenerateAccessToken(loginDto.UserName),
                    RefreshToken = await _authRepository.GenerateRefreshToken(loginDto.UserName)
                };

                return Ok(accessTokenDto);
            }

            return Unauthorized("Geçersiz kullanıcı adı veya parola.");
        }
    }
}
