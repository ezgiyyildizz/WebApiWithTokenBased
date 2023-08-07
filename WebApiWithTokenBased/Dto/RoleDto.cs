using System.ComponentModel.DataAnnotations;

public class RoleDto
{
    [Required(ErrorMessage = "Rol adı boş bırakılamaz")]
    public string RoleName { get; set; }

    [Required(ErrorMessage = "Rol açıklaması boş bırakılamaz")]
    public string Description { get; set; }

    public string CreatedBy { get; set; } = "System";
    public bool IsActive { get; set; } = true;
}