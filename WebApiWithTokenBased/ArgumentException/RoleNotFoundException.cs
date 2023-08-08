// Özel istisna sınıfı
public class RoleNotFoundException : Exception
{
    // Varsayılan kurucu metot
    public RoleNotFoundException() : base("Role not found.")
    {
    }

    // Hata mesajını özelleştirilmiş olarak ayarlayan kurucu metot
    public RoleNotFoundException(string message) : base(message)
    {
    }

    // Özelleştirilmiş mesaj ve iç içe istisna durumunu ele alan kurucu metot
    public RoleNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
