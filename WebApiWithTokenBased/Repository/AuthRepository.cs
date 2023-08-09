using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApiWithTokenBased.Dto;
using WebApiWithTokenBased.EFCore;
using WebApiWithTokenBased.Helpers;
using WebApiWithTokenBased.Models;


//Kimlik doğrulama ve yetkilendirme işlemleri
public class AuthRepository : IAuthRepository
{
    private readonly ILoggerService _logger;
    private readonly UserManager<UserCredentials> _manager;
    private readonly TokenManager _tokenManager;
    private readonly RepositoryContext _dbContext;

    public AuthRepository(UserManager<UserCredentials> manager, TokenManager tokenManager, RepositoryContext dbContext, ILoggerService logger)
    {
        _manager = manager;
        _tokenManager = tokenManager;
        _dbContext = dbContext;
        _logger = logger;
    }

    // Kullanıcı kaydı metodu
    public async Task<Dictionary<string, string>> Register(RegistrationDto registrationDto)
    {
        var user = new UserCredentials
        {
            UserName = registrationDto.UserName,
            Email = registrationDto.Email,
            FirstName = registrationDto.FirstName,
            LastName = registrationDto.LastName,
            PhoneNumber = registrationDto.PhoneNumber,
            
        };

        var result = await _manager.CreateAsync(user, registrationDto.Password);

        if (result.Succeeded)
        {
            await _manager.AddToRolesAsync(user, registrationDto.Roles);

            await _dbContext.SaveChangesAsync();

            string accessToken = await GenerateAccessToken(user.UserName);
            string refreshToken = await GenerateRefreshToken(user.UserName);

            var tokenDictionary = new Dictionary<string, string>
            {
                { "accessToken", accessToken },
                { "refreshToken", refreshToken }
            };

            return tokenDictionary;
        }

        return null;
    }

    // Kullanıcı giriş metodu
    public async Task<bool> Login(LoginDto userForLogin)
    {
        var user = await _manager.FindByNameAsync(userForLogin.UserName);

        if (user != null && await _manager.CheckPasswordAsync(user, userForLogin.Password))
            return true;

        return false;
    }

    // Access token oluşturma metodu
    public async Task<string> GenerateAccessToken(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return null;
        }
        var user = await _manager.FindByNameAsync(username);
        return _tokenManager.GenerateAccessToken(username, user.Email, user.PhoneNumber);
    }

    // Refresh token oluşturma metodu
    public async Task<string> GenerateRefreshToken(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return null;
        }

        var user = await _manager.FindByNameAsync(username);

        return _tokenManager.GenerateRefreshToken(username, user.Email, user.PhoneNumber);
    }

    // Token yenileme metodu
    public async Task<AccessTokenDto> RefreshToken(RefreshTokenDto refreshTokenDto)
    {
        if (string.IsNullOrEmpty(refreshTokenDto.RefreshToken))
        {
            return null;
        }

        var principal = _tokenManager.GetPrincipalFromToken(refreshTokenDto.RefreshToken);
        if (principal == null)
        {
            return null;
        }

        var user = await _manager.FindByNameAsync(principal.Identity.Name);
        if (user == null)
        {
            return null;
        }

        bool isRefreshTokenValid = _tokenManager.ValidateToken(refreshTokenDto.RefreshToken);

        if (!isRefreshTokenValid)
        {
            return null;
        }

        var newAccessToken = await GenerateAccessToken(principal.Identity.Name);
        var newRefreshToken = await GenerateRefreshToken(principal.Identity.Name);

        var newTokenSet = new AccessTokenDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        };

        return newTokenSet;
    }

    // Kullanıcı adına göre kullanıcıyı getirme metodu
    public async Task<UserCredentials> GetUserByName(string userName)
    {
        if (string.IsNullOrEmpty(userName))
        {
            return null;
        }

        return await _manager.FindByNameAsync(userName);
    }

    // Kullanıcı güncelleme metodu
    public async Task UpdateUser(UserCredentials user)
    {
        var existingUser = await _manager.FindByIdAsync(user.Id);

        if (existingUser == null)
        {
            _logger.LogWarning($"User not found. : {user}");
            throw new Exception("User not found.");
        }

        existingUser.UserName = user.UserName;
        existingUser.Email = user.Email;
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;

        var updateResult = await _manager.UpdateAsync(existingUser);

        if (!updateResult.Succeeded)
        {
            _logger.LogWarning($"Role could not be updated. : {existingUser}");
            throw new Exception("Failed to update user.");
        }

        await _dbContext.SaveChangesAsync();
    }

    // Kullanıcının rollerini getirme metodu
    public async Task<IList<string>> GetRolesForUser(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            _logger.LogWarning($"User not found. : {username}");
            throw new ArgumentNullException(nameof(username));
        }

        var user = await _manager.FindByNameAsync(username);
        if (user == null)
        {
            _logger.LogWarning($"User not found. : {username}");
            throw new ArgumentException("User not found.", nameof(username));
        }

        return await _manager.GetRolesAsync(user);
    }

    // Roldeki kullanıcıları getirme metodu
    public async Task<IList<UserCredentials>> GetUsersInRole(string roleName)
    {
        if (string.IsNullOrEmpty(roleName))
        {
            _logger.LogWarning($"Role name is empty : {roleName}");
            throw new ArgumentNullException(nameof(roleName));
        }

        var role = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
        if (role == null)
        {
            _logger.LogWarning($"Role not found.");
            throw new ArgumentException("Role not found.", nameof(roleName));
        }

        return await _manager.GetUsersInRoleAsync(roleName);
    }

    public async Task<List<string>> GetClaimsValue(string token)
    {
        // İlgili token ile ilgili claims bilgilerini elde etmek için token yöneticisi
        var principal = _tokenManager.GetPrincipalFromToken(token);

        // Claims değerlerini saklamak için yeni bir liste 
        var listClaim = new List<string>();

        // Her bir claim için döngüye giriliyor
        foreach (var claim in principal.Claims)
        {
            // Eğer claim tipi e-posta veya mobil telefon numarası ise
            if (claim.Type == ClaimTypes.Email || claim.Type == ClaimTypes.MobilePhone)
            {
                // Bu claim'in değeri listeye eklenir
                listClaim.Add(claim.Value);
            }
        }

        // İlgili kullanıcının e-posta veya telefon numarası claim değerlerini içeren liste döndürme
        return listClaim;
    }
}