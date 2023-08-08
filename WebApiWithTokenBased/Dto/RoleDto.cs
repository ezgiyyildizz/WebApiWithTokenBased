using System.ComponentModel.DataAnnotations;

// Kullanıcı rollerini temsil eden veri aktarım nesnesi
public class RoleDto
{
    // Rol adını temsil eden özellik; zorunlu alan ve hata mesajı 
    [Required(ErrorMessage = "Rol adı boş bırakılamaz")]
    public string RoleName { get; set; }

    // Rol açıklamasını temsil eden özellik; zorunlu alan ve hata mesajı 
    [Required(ErrorMessage = "Rol açıklaması boş bırakılamaz")]
    public string Description { get; set; }

    // Rolün oluşturan kişiyi temsil eden varsayılan değer "System"
    public string CreatedBy { get; set; } = "System";

    // Rolün etkinlik durumunu temsil eden varsayılan değer true
    public bool IsActive { get; set; } = true;
}
