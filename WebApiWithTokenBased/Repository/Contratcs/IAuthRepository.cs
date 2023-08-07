using WebApiWithTokenBased.Dto;
using WebApiWithTokenBased.Models;

public interface IAuthRepository
{
    Task<Dictionary<string, string>> Register(RegistrationDto registrationDto);
    Task<bool> Login(LoginDto userForLogin);
    string GenerateAccessToken(string username);
    Task<string> GenerateRefreshToken(string username);
    Task<AccessTokenDto> RefreshToken(RefreshTokenDto refreshTokenDto);
    Task<UserCredentials> GetUserByName(string userId);
    Task UpdateUser(UserCredentials user);
    Task<IList<string>> GetRolesForUser(string username);
    Task<IList<UserCredentials>> GetUsersInRole(string roleName);
    
}