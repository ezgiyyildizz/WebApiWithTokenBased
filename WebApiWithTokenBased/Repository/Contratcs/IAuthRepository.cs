using WebApiWithTokenBased.Dto;
using WebApiWithTokenBased.Models;

public interface IAuthRepository
{
    // Yeni bir kullanıcı kaydı oluşturma ve oluşturulan kullanıcının erişim ve yenileme token'larını döndürme
    Task<Dictionary<string, string>> Register(RegistrationDto registrationDto);

    // Kullanıcının giriş yapmasını doğrulama
    Task<bool> Login(LoginDto userForLogin);

    // Belirtilen kullanıcı adı için bir erişim tokenı 
    string GenerateAccessToken(string username);

    // Belirtilen kullanıcı adı için bir yenileme tokenı
    Task<string> GenerateRefreshToken(string username);

    // Yenileme tokenını kullanarak yeni bir erişim tokenı 
    Task<AccessTokenDto> RefreshToken(RefreshTokenDto refreshTokenDto);

    // Belirtilen kullanıcı kimliği ile kullanıcıyı getirme
    Task<UserCredentials> GetUserByName(string userId);

    // Kullanıcı bilgilerini güncelleme
    Task UpdateUser(UserCredentials user);

    // Belirtilen kullanıcı adı için rolleri getirme
    Task<IList<string>> GetRolesForUser(string username);

    // Belirtilen rol adına sahip tüm kullanıcıları getirme
    Task<IList<UserCredentials>> GetUsersInRole(string roleName);
}
