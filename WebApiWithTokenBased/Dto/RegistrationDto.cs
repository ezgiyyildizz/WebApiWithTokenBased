using System.ComponentModel.DataAnnotations;

namespace WebApiWithTokenBased.Dto
{
    // Kullanıcının kaydolması için kullandığı veri aktarım nesnesi 
    public record RegistrationDto
    {
        // Kullanıcının adını temsil eden özellik
        public string? FirstName { get; init; }

        // Kullanıcının soyadını temsil eden özellik
        public string? LastName { get; init; }

        // E-posta doğrulama kuralları 
        [EmailAddress(ErrorMessage = "Hatalı mail girdiniz.")]
        public string? Email { get; init; }

        // Telefon numarası doğrulama kuralları 
        [RegularExpression(@"^(\+\d{1,2}\s?)?[\s.-]?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Hatalı telefon numarası girdiniz.")]
        public string? PhoneNumber { get; init; }

        // Kullanıcının rollerini taşıyan koleksiyon özelliği
        public ICollection<string>? Roles { get; init; }

        // Kullanıcı adı özelliği; zorunlu alan ve hata mesajı 
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; init; }

        // Parola özelliği; zorunlu alan ve hata mesajı 
        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        public string Password { get; init; }
    }
}
