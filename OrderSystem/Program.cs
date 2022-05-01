
namespace OrderSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateApplicationBuilder().Build();

            await app.RunAsync();
        }

        public static WebApplicationBuilder CreateApplicationBuilder()
        {
            var builder = WebApplication.CreateBuilder();

            builder.WebHost.UseStartup<Startup>();

            return builder;
        }
    }
}
