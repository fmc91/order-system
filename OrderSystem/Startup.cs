using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using AutoMapper;
using DomainLayer.Profiles;

namespace OrderSystem
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(routes =>
            {
                routes.MapControllers();
                routes.MapFallbackToFile("index.html");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AutoMapper.IConfigurationProvider>(CreateMapperConfig());

            services.AddControllers();

            services.AddCors(options =>
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                })
            );

            services.AddTransient<IMapper, Mapper>();

            services.AddDbContext<OrderSystemContext>(builder =>
            {
                builder.UseSqlServer(_configuration.GetConnectionString("OrderSystem"))
                    .UseLazyLoadingProxies();
            });
        }

        private MapperConfiguration CreateMapperConfig() => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        });
    }
}
