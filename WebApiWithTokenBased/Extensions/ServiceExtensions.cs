using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiWithTokenBased.ActionFilters;
using WebApiWithTokenBased.EFCore;
using WebApiWithTokenBased.Helpers;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.Extensions
{
    public static class ServiceExtensions
    {
        // Repository servisini ekler
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoleRepository, roleRepository>();
        }

        // Veritabanı bağlantısını ekler
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string jwtSecretKey = configuration["Jwt:Key"];

            // TokenManager'ı hizmetlere ekleyin ve gizli anahtarı ekstra olarak sağlayın
            services.AddScoped(provider => new TokenManager(jwtSecretKey));
            
            // Configure JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"], // Use the provided issuer from the configuration
                        ValidAudience = configuration["Jwt:Audience"], // Use the provided audience from the configuration
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)) // Use the provided jwtSecretKey
                    };
                });
        }
        
        // Kimlik doğrulama servisini ekler
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<UserCredentials, UserRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 6;

                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();

        }
    }
}
