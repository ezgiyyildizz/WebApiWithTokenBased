using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApiWithTokenBased.Models;

namespace WebApiWithTokenBased.EFCore
{
    public class RepositoryContext : IdentityDbContext<UserCredentials>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Model sınıflarınıza ve ilişkilerinize göre model oluşturmayı devraldığınızda, gerekli özelleştirmeleri burada yapabilirsiniz.
            // Örneğin, ilişkileri, indeksleri, sütun tiplerini veya varsayılan değerleri yapılandırabilirsiniz.
            // Bu örnek proje için herhangi bir özelleştirme gerekmiyor, bu yüzden boş bırakıyoruz.
        }
    }
}
