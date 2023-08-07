using Microsoft.AspNetCore.Mvc;
using WebApiWithTokenBased.Dto;

namespace WebApiWithTokenBased.Controllers
{
    // Bu controller, token yenileme işlemlerini yönetmek için kullanılır.
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshController : ControllerBase
    {
        private readonly IAuthRepository _repository;

        // RefreshController sınıfının yapıcı metodu.
        // IAuthRepository parametresi, token yenileme işlemleri için kullanılacak veritabanı işlemleri arayüzüdür.
        public RefreshController(IAuthRepository repository)
        {
            _repository = repository;
        }

        // HTTP POST metodu ile çağrılacak olan aksiyon, verilen erişim token'ını yeniler ve yeni bir erişim token'ı döndürür.
        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var token = await _repository.RefreshToken(refreshTokenDto);

            return Ok(token);
        }
    }
}
