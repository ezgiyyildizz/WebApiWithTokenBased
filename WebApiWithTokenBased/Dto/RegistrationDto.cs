using System.ComponentModel.DataAnnotations;

namespace WebApiWithTokenBased.Dto
{
    // Kullanıcının kaydolması için kullandığı veri aktarım nesnesi 
    public record RegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }

        [EmailAddress(ErrorMessage = "Hatalı mail girdiniz.")]
        public string? Email { get; init; }

        [RegularExpression(@"^(\+\d{1,2}\s?)?[\s.-]?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage ="Hatalı telefon numarası girdiniz.")]
        public string? PhoneNumber { get; init; }
        public ICollection<string>? Roles { get; init; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; init; }

        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        public string Password { get; init; }
    }
}
