namespace WebApiWithTokenBased.Dto
{
    // Erişim ve yenileme (refresh) token'larını taşıyan DTO sınıfı
    public class AccessTokenDto
    {
        // Erişim token'ını temsil eden özellik
        public string? AccessToken { get; set; }

        // Yenileme token'ını temsil eden özellik
        public string? RefreshToken { get; set; }
    }
}
