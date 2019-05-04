using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Narik.Common.Web.Infrastructure;
using Unity.Microsoft.DependencyInjection;

namespace NarikStarter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
       
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUnityServiceProvider()
                .UseAndConfigNarik()
                .UseStartup<Startup>();
    }
}
