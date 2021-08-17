using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using MediatR_WebApplication.KitchenApp;
using MediatR_WebApplication.WeatherForecastApp;

namespace MediatR_WebApplication
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
            services.AddControllers();

            services.AddMediatR(typeof(Startup));

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new() { Title = "RESTful API with MediatR", Version = "v1" });
                    c.SupportNonNullableReferenceTypes();
                });

            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddSingleton<DishRepository>();
            services.AddTransient<IRetrieve<Guid, Dish>>(c => c.GetService<DishRepository>());
            services.AddTransient<ICreate<Dish>>(c => c.GetService<DishRepository>());
            services.AddTransient<IUpdate<Dish>>(c => c.GetService<DishRepository>());
            services.AddTransient<IDelete<Guid>>(c => c.GetService<DishRepository>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RESTful API with MediatR"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
