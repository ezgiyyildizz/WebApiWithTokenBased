using NLog;
using WebApiWithTokenBased.Extensions;

namespace WebApiWithTokenBased
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // Uygulama yap�land�rmas� i�in kullan�lan IConfiguration nesnesi
        public IConfiguration configuration { get; }

        // Hizmetleri yap�land�rma metodu
        public void ConfigureServices(IServiceCollection services)
        {

            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // Controller'lar� ekler ve ilgili uygulama bile�enini tan�r
            services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);

            // Veritaban� ba�lant�s� ve yap�land�rmas� i�in servisleri ayarlar
            services.ConfigureSqlServer(configuration);

            // Repository ve Entity Framework Core yap�land�rmas�n� ekler
            services.ConfigureRepository();


            services.ConfigureLoggerService();

            // Kimlik do�rulama ve yetkilendirme ayarlar�n� ekler
            services.ConfigureIdentity();

            // Kimlik do�rulama i�lemi i�in yap�land�rmay� ger�ekle�tirir
            services.ConfigureAuthentication(configuration);

            // API ke�fini ve Swagger belgelerini ekler
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // AutoMapper'� yap�land�r�r
            services.AddAutoMapper(typeof(Startup));
        }

        // Uygulama y�r�tme a�amas�n�n yap�land�r�lmas� metodu
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Hata sayfas�n� geli�tirme modunda g�sterir
                app.UseDeveloperExceptionPage();
                // Swagger ve SwaggerUI'� etkinle�tirir
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var logger = app.ApplicationServices.GetRequiredService<ILoggerService>();

            // HTTP'den HTTPS'ye y�nlendirme yapar
            app.UseHttpsRedirection();

            // Y�nlendirmeyi ve kimlik do�rulama y�ntemlerini belirler
            app.UseRouting();

            // Kimlik do�rulamay� uygular
            app.UseAuthentication();

            // Yetkilendirme i�lemini uygular
            app.UseAuthorization();

            // Controller endpoint'lerini belirler
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
