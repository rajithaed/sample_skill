using Challenge.General.Api.Configuration;
using Challenge.General.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Challenge.General.Api
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
            services.AddMvc();

            //setup IoC
            SetupIoC(services);

            //setup Swagger
            SetupSwagger(services);
        }

        private void SetupIoC(IServiceCollection services)
        {
            services.AddSingleton<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<IFoodStandardsService, FoodStandardsService>();
            services.AddSingleton<IFootballService, FootballService>();
        }

        private static void SetupSwagger(IServiceCollection services)
        {
            //Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "Infinity Works - Challenge", Version = "v1"});
            });
            services.AddMvcCore()
                .AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Challenge V1"); });
        }
    }
}