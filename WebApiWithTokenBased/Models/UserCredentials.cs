using Microsoft.AspNetCore.Identity;

namespace WebApiWithTokenBased.Models
{
    // Kullanıcının kimlik bilgilerini içeren sınıf
    public class UserCredentials : IdentityUser
    {
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
    }
}
