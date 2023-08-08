namespace WebApiWithTokenBased.Dto
{
    // Yenileme (refresh) token'ını taşıyan veri aktarım nesnesi
    public record class RefreshTokenDto
    {
        // Yenileme token'ını temsil eden özellik
        public string? RefreshToken { get; init; }
    }
}
