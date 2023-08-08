using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.EFCore
{
    // Veritabanı bağlamı sınıfı, kimlik doğrulama entegrasyonu ile
    public class RepositoryContext : IdentityDbContext<UserCredentials>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tüm yapılandırma sınıflarını bulan ve uygulayan çağrı
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}

