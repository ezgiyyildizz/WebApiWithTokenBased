using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApiWithTokenBased.EFCore;

namespace WebApiWithTokenBased.RepositoryContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            // appsettings.json dosyasından veritabanı bağlantı bilgilerini almak için yapılandırma
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // DbContext için gerekli seçenekleri ayarlayarak bir DbContextOptionsBuilder oluştur
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                prj => prj.MigrationsAssembly("WebApiWithTokenBased"));

            // Oluşturulan seçeneklerle yeni RepositoryContext nesnesini oluşturup geri döndür
            return new RepositoryContext(builder.Options);
        }
    }
}
