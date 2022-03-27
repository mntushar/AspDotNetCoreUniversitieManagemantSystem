using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace UniversitieManagemantSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var host = Host.CreateDefaultBuilder(args)
            //       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            //       .ConfigureWebHostDefaults(webHostBuilder =>
            //       {
            //           webHostBuilder
            //            .UseContentRoot(Directory.GetCurrentDirectory())
            //            .UseIISIntegration()
            //            .UseStartup<Startup>();
            //       })
            //       .Build();

            //host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
