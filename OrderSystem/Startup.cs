using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.EntityFrameworkCore;
using DataLayer;
using DataLayer.Model;
using OrderSystem.Model;
using OrderSystem.Profiles;

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

            services.AddScoped<RepositoryProvider>();

            services.AddScoped<IRepository<ProductModel, Product>, Repository<ProductModel, Product>>()
                .AddScoped<IRepository<OrderModel, Order>, Repository<OrderModel, Order>>()
                .AddScoped<IRepository<StockItemModel, StockItem>, Repository<StockItemModel, StockItem>>();
        }

        private MapperConfiguration CreateMapperConfig(IServiceCollection services) => new MapperConfiguration(cfg =>
        {
            cfg.AddCollectionMappers();
            cfg.UseEntityFrameworkCoreModel<OrderSystemContext>(services);
            cfg.AddProfile<ProductProfile>();
        });
    }
}
