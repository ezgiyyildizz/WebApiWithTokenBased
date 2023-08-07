namespace WebApiWithTokenBased.Dto
{
    public class AccessTokenDto
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
