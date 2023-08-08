namespace WebApiWithTokenBased.Dto
{
    // Rol adı ve izin bilgilerini taşıyan DTO sınıfı
    public class ClaimDto
    {
        // İlgili rol adını temsil eden özellik
        public string RoleName { get; init; }

        // İzin türünü (claim type) temsil eden özellik
        public string ClaimType { get; init; }

        // İzin değerini (claim value) temsil eden özellik
        public string ClaimValue { get; init; }
    }
}
