using Microsoft.EntityFrameworkCore;

namespace TravelXP.Moviles.API.Context
{
    public class startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar el contexto de la base de datos
            services.AddDbContext<APPDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("Connection"),
                                 new MySqlServerVersion(new Version(8, 0, 23))));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
