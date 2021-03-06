using Kolokwium.Models;
using Kolokwium.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
namespace Kolokwium
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RemizaDbContext>(options => options.UseSqlServer(Configuration["dbConnectionString"]));
            services.AddScoped<IRemizaDbService, SqlServerRemizaDbService>();
            services.AddControllers();
            services.AddSwaggerGen(config =>
               config.SwaggerDoc("v1", new OpenApiInfo { Title = "Remiza API", Version = "v1" })
           );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config =>
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Kolokwium Retake API")
            );


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
