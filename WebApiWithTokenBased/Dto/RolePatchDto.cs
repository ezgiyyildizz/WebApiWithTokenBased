// Rolün kısmi güncelleme veri aktarım nesnesi
public class RolePatchDto
{
    // Rol açıklamasını temsil eden özellik
    public string Description { get; set; }

    // Rolün etkinlik durumunu temsil eden özellik; null değeri de alabilir
    public bool? IsActive { get; set; }
}
