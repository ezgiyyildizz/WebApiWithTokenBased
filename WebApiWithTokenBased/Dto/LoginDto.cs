using System.ComponentModel.DataAnnotations;

namespace WebApiWithTokenBased.Dto
{
    // Kullanıcının giriş yapmak için kullandığı veri aktarım nesnesi
    public record LoginDto
    {
        // Kullanıcı adı özelliği; zorunlu alan ve hata mesajı 
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string? UserName { get; init; }

        // Parola özelliği; zorunlu alan ve hata mesajı 
        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        public string? Password { get; init; }
    }
}
