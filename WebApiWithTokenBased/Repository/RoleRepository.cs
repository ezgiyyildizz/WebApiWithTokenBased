using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApiWithTokenBased.EFCore;
using WebApiWithTokenBased.Models;

public class roleRepository : IRoleRepository
{
    private readonly RoleManager<UserRole> _roleManager;
    private readonly UserManager<UserCredentials> _userManager;
    private readonly RepositoryContext _dbContext;

    public roleRepository(RoleManager<UserRole> roleManager, UserManager<UserCredentials> userManager, RepositoryContext dbContext)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _dbContext = dbContext;
    }

    // Yeni bir rolü sisteme ekler
    public void AddRole(string roleName, string description, string createdBy, bool isActive)
    {
        // Yeni bir UserRole örneği
        var role = new UserRole
        {
            Name = roleName,
            Description = description,
            CreatedBy = createdBy,
            IsActive = isActive,
            CreatedAt = DateTime.Now
        };

        // Rolu asenkron olarak oluşturur
        _roleManager.CreateAsync(role).GetAwaiter().GetResult();
    }

    // Tüm rol isimlerinin bir listesini döndürür
    public IEnumerable<string> GetAllRoles()
    {
        return _roleManager.Roles.Select(r => r.Name);
    }

    // İsmine göre bir rolü getirir
    public UserRole GetRoleById(string name)
    {
        return _roleManager.FindByNameAsync(name).GetAwaiter().GetResult();
    }

    // Mevcut bir rolün bilgisini günceller
    public void UpdateRole(string roleName, UserRole role)
    {
        var userRole = _roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
        if (role != null)
        {
            // Rol özelliklerini güncelleme
            userRole.Name = role.Name;
            userRole.Description = role.Description;
            userRole.CreatedBy = role.CreatedBy;
            userRole.IsActive = role.IsActive;

            // Rolü asenkron olarak güncelleme
            _roleManager.UpdateAsync(role).GetAwaiter().GetResult();
        }
    }

    // Sistemden bir rolü siler
    public void DeleteRole(string name)
    {
        var role = _roleManager.FindByNameAsync(name).GetAwaiter().GetResult();
        if (role != null)
        {
            // Rolü asenkron olarak silme
            _roleManager.DeleteAsync(role).GetAwaiter().GetResult();
        }
    }

    // Bir kullanıcıya birden fazla rol atar
    public async Task AssignRolesToUser(UserCredentials user, IEnumerable<string> roles)
    {
        // Kullanıcının şu anki rolleri
        var userRoles = await _userManager.GetRolesAsync(user);
        // Atanacak roller (daha önce atanmamış roller)
        var rolesToAdd = roles.Except(userRoles);

        // Her rolün atanabilir olup olmadığını kontrol eder
        foreach (var role in rolesToAdd)
        {
            if (!_roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
            {
                throw new RoleNotFoundException();
            }
        }

        // Her yeni rolü kullanıcıya atar
        foreach (var role in rolesToAdd)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }

    // Bir kullanıcıdan birden fazla rolü çıkarır
    public async Task RemoveRolesFromUser(UserCredentials user, IEnumerable<string> roles)
    {
        // Her rolü kullanıcıdan çıkarır
        foreach (var role in roles)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }
    }

    // Verilen kullanıcının rollerini getirir
    public async Task<IList<string>> GetRolesForUser(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException(nameof(username));
        }

        // Kullanıcıyı kullanıcı adına göre bulur
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı.", nameof(username));
        }

        // Kullanıcıya atanmış rolleri getirir
        return await _userManager.GetRolesAsync(user);
    }

    // Verilen roldeki kullanıcıları getirir
    public async Task<IList<UserCredentials>> GetUsersInRole(string roleName)
    {
        if (string.IsNullOrEmpty(roleName))
        {
            throw new ArgumentNullException(nameof(roleName));
        }

        // Rolü ismine göre bulur
        var role = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
        if (role == null)
        {
            throw new ArgumentException("Rol bulunamadı.", nameof(roleName));
        }

        // Kullanıcı sorgulamadan önce rolün varlığını kontrol eder
        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
        {
            throw new ArgumentException("Rol bulunamadı.", nameof(roleName));
        }

        // Role atanmış kullanıcıları getirir
        return await _userManager.GetUsersInRoleAsync(roleName);
    }

    // Bir kullanıcıya bir rol için yetki ekler
    public async Task AddRoleClaimToUser(string roleName, string claimType, string claimValue)
    {
        // Giriş parametrelerini doğrular
        if (string.IsNullOrEmpty(roleName) || string.IsNullOrEmpty(claimType) || string.IsNullOrEmpty(claimValue))
        {
            throw new ArgumentNullException("Rol adı, yetki türü ve değeri boş olamaz.");
        }

        // Rolü ismine göre bulur
        var role = await _roleManager.FindByNameAsync(roleName);
        var claim = new Claim(claimType, claimValue);

        // Yetkiyi role ekler
        await _roleManager.AddClaimAsync(role, claim);
    }

    // Bir rolün bir iznini (yetkisini) kaldırır
    public async Task<bool> RemovePermissionFromRole(string roleName, string claimType, string claimValue)
    {
        // Rolü ismine göre bulur
        var role = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
        if (role == null)
        {
            throw new ArgumentException("Rol bulunamadı.", nameof(roleName));
        }

        // Rolden mevcut yetkiyi bulur
        var existingClaim = await _dbContext.RoleClaims.FirstOrDefaultAsync(c =>
            c.RoleId == role.Id && c.ClaimType == claimType && c.ClaimValue == claimValue);

        if (existingClaim == null)
        {
            // Belirtilen izin role atanmazsa
            return false;
        }

        // Yetkiyi rolden kaldır
        _dbContext.RoleClaims.Remove(existingClaim);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
