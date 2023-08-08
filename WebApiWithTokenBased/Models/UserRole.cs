using Microsoft.AspNetCore.Identity;

public class UserRole : IdentityRole
{
    public DateTime CreatedAt { get; set; } // Rolün oluşturulma tarihi
    public string Description { get; set; } = "Default Description"; // Rolün açıklaması
    public string CreatedBy { get; set; } = "System"; // Rolün kim tarafından oluşturulduğu
    public bool IsActive { get; set; } // Rolün etkinlik durumu
}
