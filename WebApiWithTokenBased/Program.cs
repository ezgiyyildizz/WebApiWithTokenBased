using NLog;

namespace WebApiWithTokenBased
{
    // Uygulama ana giriş noktası
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            
            // Ana geliştirme sunucusunu oluşturur ve çalıştırır
            CreateHostBuilder(args).Build().Run();

        }

        // Ana sunucu yapılandırmasını oluşturan metot
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Web uygulama başlatıcısını belirtir
                    webBuilder.UseStartup<Startup>();
                });


    }
}
