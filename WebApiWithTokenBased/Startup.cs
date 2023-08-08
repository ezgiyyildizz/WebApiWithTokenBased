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

        // Uygulama yapýlandýrmasý için kullanýlan IConfiguration nesnesi
        public IConfiguration configuration { get; }

        // Hizmetleri yapýlandýrma metodu
        public void ConfigureServices(IServiceCollection services)
        {

            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            // Controller'larý ekler ve ilgili uygulama bileþenini tanýr
            services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);

            // Veritabaný baðlantýsý ve yapýlandýrmasý için servisleri ayarlar
            services.ConfigureSqlServer(configuration);

            // Repository ve Entity Framework Core yapýlandýrmasýný ekler
            services.ConfigureRepository();


            services.ConfigureLoggerService();

            // Kimlik doðrulama ve yetkilendirme ayarlarýný ekler
            services.ConfigureIdentity();

            // Kimlik doðrulama iþlemi için yapýlandýrmayý gerçekleþtirir
            services.ConfigureAuthentication(configuration);

            // API keþfini ve Swagger belgelerini ekler
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // AutoMapper'ý yapýlandýrýr
            services.AddAutoMapper(typeof(Startup));
        }

        // Uygulama yürütme aþamasýnýn yapýlandýrýlmasý metodu
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Hata sayfasýný geliþtirme modunda gösterir
                app.UseDeveloperExceptionPage();
                // Swagger ve SwaggerUI'ý etkinleþtirir
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var logger = app.ApplicationServices.GetRequiredService<ILoggerService>();

            // HTTP'den HTTPS'ye yönlendirme yapar
            app.UseHttpsRedirection();

            // Yönlendirmeyi ve kimlik doðrulama yöntemlerini belirler
            app.UseRouting();

            // Kimlik doðrulamayý uygular
            app.UseAuthentication();

            // Yetkilendirme iþlemini uygular
            app.UseAuthorization();

            // Controller endpoint'lerini belirler
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
