using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using DomainLayer.Profiles;
using AutoMapper.EntityFrameworkCore;
using DomainLayer;

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

            services.AddSingleton<AutoMapper.IConfigurationProvider>(CreateMapperConfig(services));

            services.AddScoped<ICarrierService, CarrierService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IDistributionCentreService, DistributionCentreService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>();
        }

        private MapperConfiguration CreateMapperConfig(IServiceCollection services) => new MapperConfiguration(cfg =>
        {
            cfg.AddCollectionMappers();
            cfg.UseEntityFrameworkCoreModel<OrderSystemContext>(services);
            cfg.AddProfile<ProductProfile>();
        });
    }
}
