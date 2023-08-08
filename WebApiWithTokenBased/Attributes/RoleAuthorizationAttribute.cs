using Microsoft.AspNetCore.Authorization;

// Rol tabanlı yetkilendirme için özel bir öznitelik 
public class RoleAuthorizationAttribute : AuthorizeAttribute
{
    public RoleAuthorizationAttribute(params string[] roles)
    {
        Roles = string.Join(",", roles);
    }
}
