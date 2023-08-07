using System.ComponentModel.DataAnnotations;

namespace WebApiWithTokenBased.Dto
{
    // Kullanıcının giriş yapmak için kullandığı veri aktarım nesnesi
    public record LoginDto
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string? UserName { get; init; }

        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        public string? Password { get; init; }
    }
}
