using Microsoft.AspNetCore.Identity;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.Extensions
{
    public static class IdentityExtensions
    {
        public static async Task SetTokenAsync(this UserManager<UserCredentials> userManager, UserCredentials user, string loginProvider, string name, string value)
        {
            var token = await userManager.GetAuthenticationTokenAsync(user, loginProvider, name);
            if (token == null)
            {
                await userManager.SetAuthenticationTokenAsync(user, loginProvider, name, value);
            }
            else
            {
                await userManager.RemoveAuthenticationTokenAsync(user, loginProvider, name);
                await userManager.SetAuthenticationTokenAsync(user, loginProvider, name, value);
            }
        }
    }
}
