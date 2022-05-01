using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using DataLayer;

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

            app.UseEndpoints(routes =>
            {
                routes.MapControllers();
                routes.MapFallbackToFile("index.html");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<OrderSystemContext>(builder =>
            {
                builder.UseSqlServer(_configuration.GetConnectionString("OrderSystem"))
                    .UseLazyLoadingProxies();
            });
        }
    }
}
