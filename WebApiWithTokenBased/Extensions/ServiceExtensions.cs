using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiWithTokenBased.EFCore;
using WebApiWithTokenBased.Helpers;
using WebApiWithTokenBased.Models;
using WebApiWithTokenBased.Repository;

namespace WebApiWithTokenBased.Extensions
{
    public static class ServiceExtensions
    {
        // Repository servisi
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoleRepository, roleRepository>();
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();

        // Veritabanı bağlantısı
        public static void ConfigureSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        // Kimlik doğrulama işlemleri
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string jwtSecretKey = configuration["Jwt:Key"];

            // TokenManager'ı hizmetlere ekleme ve gizli anahtarı ekstra olarak sağlama
            services.AddScoped(provider => new TokenManager(jwtSecretKey, configuration));

            // JWT kimlik doğrulama işlemi
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"], 
                        ValidAudience = configuration["Jwt:Audience"], 
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)) 
                    };
                });
        }

        // Kimlik doğrulama servisini yapılandırır
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
