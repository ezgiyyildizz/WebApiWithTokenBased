using WebApiWithTokenBased.Models;

public interface IRoleRepository
{
    // Yeni bir rol ekler
    void AddRole(string roleName, string description, string createdBy, bool isActive);

    // Tüm rolleri getirir
    IEnumerable<string> GetAllRoles();

    // Belirtilen rol adına sahip rolü getirir
    UserRole GetRoleById(string name);

    // Bir rolün bilgilerini günceller
    void UpdateRole(string roleName, UserRole role);

    // Belirtilen rolü siler
    void DeleteRole(string name);

    // Kullanıcıya roller atar
    Task AssignRolesToUser(UserCredentials user, IEnumerable<string> roles);

    // Kullanıcının rollerini kaldırır
    Task RemoveRolesFromUser(UserCredentials user, IEnumerable<string> roles);

    // Bir kullanıcıya rol için talep ekler
    Task AddRoleClaimToUser(string role, string claimType, string claimValue);

    // Bir rolün iznini kaldırır
    Task<bool> RemovePermissionFromRole(string roleName, string claimType, string claimValue);
}
