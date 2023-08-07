using System.Collections.Generic;
using WebApiWithTokenBased.Models;

public interface IRoleRepository
{
    void AddRole(string roleName, string description, string createdBy, bool isActive);
    IEnumerable<string> GetAllRoles();
    UserRole GetRoleById(string name);
    void UpdateRole(string roleName, UserRole role);
    void DeleteRole(string name);
    Task AssignRolesToUser(UserCredentials user, IEnumerable<string> roles);
    Task RemoveRolesFromUser(UserCredentials user, IEnumerable<string> roles);
    Task AddRoleClaimToUser(string role, string claimType, string claimValue);
    Task<bool> RemovePermissionFromRole(string roleName, string claimType, string claimValue);
}
