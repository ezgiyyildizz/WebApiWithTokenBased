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

    // Yeni rol ekleme metodu
    public void AddRole(string roleName, string description, string createdBy, bool isActive)
    {
        var role = new UserRole
        {
            Name = roleName,
            Description = description,
            CreatedBy = createdBy,
            IsActive = isActive,
            CreatedAt = DateTime.Now
        };

        _roleManager.CreateAsync(role).GetAwaiter().GetResult();
    }

    // Tüm rolleri listeleme metodu
    public IEnumerable<string> GetAllRoles()
    {
        return _roleManager.Roles.Select(r => r.Name);
    }

    // Bir rolü ID'ye göre getirme metodu
    public UserRole GetRoleById(string name)
    {
        return _roleManager.FindByNameAsync(name).GetAwaiter().GetResult();
    }

    // Rol güncelleme metodu
    public void UpdateRole(string roleName, UserRole role)
    {
        var userRole = _roleManager.FindByNameAsync(roleName).GetAwaiter().GetResult();
        if (role != null)
        {
            userRole.Name = role.Name;
            userRole.Description = role.Description;
            userRole.CreatedBy = role.CreatedBy;
            userRole.IsActive = role.IsActive;

            _roleManager.UpdateAsync(role).GetAwaiter().GetResult();
        }
    }

    // Rol silme metodu
    public void DeleteRole(string name)
    {
        var role = _roleManager.FindByNameAsync(name).GetAwaiter().GetResult();
        if (role != null)
        {
            _roleManager.DeleteAsync(role).GetAwaiter().GetResult();
        }
    }

    public async Task AssignRolesToUser(UserCredentials user, IEnumerable<string> roles)
    {
        // Kullanıcıya verilen rollerin hepsini alın ve bu rolleri kullanıcının rolleri arasında olmayanlar olarak belirleyin
        var userRoles = await _userManager.GetRolesAsync(user);
        var rolesToAdd = roles.Except(userRoles);

        // Olmayan bir rol atandığında istisna fırlat
        foreach (var role in rolesToAdd)
        {
            if (!_roleManager.RoleExistsAsync(role).GetAwaiter().GetResult())
            {
                throw new RoleNotFoundException();
            }
        }

        // Kullanıcıyı her yeni rolle eşleştirin
        foreach (var role in rolesToAdd)
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }


    // Kullanıcıdan rolleri çıkarma metodu
    public async Task RemoveRolesFromUser(UserCredentials user, IEnumerable<string> roles)
    {
        // Kullanıcının verilen rolleri çıkarın
        foreach (var role in roles)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }
    }

    // Kullanıcının rollerini getirme metodu
    public async Task<IList<string>> GetRolesForUser(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentNullException(nameof(username));
        }

        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            throw new ArgumentException("User not found.", nameof(username));
        }

        return await _userManager.GetRolesAsync(user);
    }

    // Roldeki kullanıcıları getirme metodu
    public async Task<IList<UserCredentials>> GetUsersInRole(string roleName)
    {
        if (string.IsNullOrEmpty(roleName))
        {
            throw new ArgumentNullException(nameof(roleName));
        }

        var role = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
        if (role == null)
        {
            throw new ArgumentException("Role not found.", nameof(roleName));
        }

        // Olmayan bir rol atandığında istisna fırlat
        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
        {
            throw new ArgumentException("Role not found.", nameof(roleName));
        }

        return await _userManager.GetUsersInRoleAsync(roleName);
    }

    // Kullanıcıya role claim ekleyen metot
    public async Task AddRoleClaimToUser(string roleName, string claimType, string claimValue)
    {

        if (string.IsNullOrEmpty(roleName))
        {
            throw new ArgumentNullException(nameof(roleName));
        }

        if (string.IsNullOrEmpty(claimType))
        {
            throw new ArgumentNullException(nameof(claimType));
        }

        if (string.IsNullOrEmpty(claimValue))
        {
            throw new ArgumentNullException(nameof(claimValue));
        }

        var role = await _roleManager.FindByNameAsync(roleName);
        var claim = new Claim(claimType, claimValue);
        await _roleManager.AddClaimAsync(role, claim); 
    }

    // İzin silme metodu
    public async Task<bool> RemovePermissionFromRole(string roleName, string claimType, string claimValue)
    {
        var role = await _dbContext.Roles.SingleOrDefaultAsync(r => r.Name == roleName);
        if (role == null)
        {
            throw new ArgumentException("Rol bulunamadı.", nameof(roleName));
        }

        var existingClaim = await _dbContext.RoleClaims.FirstOrDefaultAsync(c =>
            c.RoleId == role.Id && c.ClaimType == claimType && c.ClaimValue == claimValue);

        if (existingClaim == null)
        {
            // Belirtilen izin, role atanmamış.
            return false;
        }

        _dbContext.RoleClaims.Remove(existingClaim);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
