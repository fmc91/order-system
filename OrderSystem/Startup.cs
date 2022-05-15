using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.EntityFrameworkCore;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using OrderSystem.Profiles;
using DataLayer.Repositories;

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

            services.AddScoped<ICarrierRepository, CarrierRepository>()
                .AddScoped<ICategoryRepository, CategoryRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IDistributionCentreRepository, DistributionCentreRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IRegionRepository, RegionRepository>()
                .AddScoped<IStockItemRepository, StockItemRepository>();
        }

        private MapperConfiguration CreateMapperConfig(IServiceCollection services) => new MapperConfiguration(cfg =>
        {
            cfg.AddCollectionMappers();
            cfg.UseEntityFrameworkCoreModel<OrderSystemContext>(services);
            cfg.AddProfile<ProductProfile>();
        });
    }
}
