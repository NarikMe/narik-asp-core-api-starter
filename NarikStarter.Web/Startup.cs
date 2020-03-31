using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Narik.Common.Web.Infrastructure;
using Unity;
using Microsoft.Extensions.Hosting;

namespace NarikStarter.Web
{
    public class Startup
    {
        public IUnityContainer Container { get; }
        public IConfiguration Configuration;
        private readonly NarikStartup _narikStartup;

        public Startup(IUnityContainer container, IConfiguration configuration)
        {
            Container = container;
            Configuration = configuration;
            _narikStartup=new NarikStartup(configuration,container);
        }


        public void ConfigureContainer(IUnityContainer container)
        {
            
        }

        //container.AddNewExtension<Interception>();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            _narikStartup.Configure(app, env);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _narikStartup.ConfigureServices(services);
        }
    }
    
}
