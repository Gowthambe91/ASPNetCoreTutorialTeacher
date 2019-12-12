using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyFirstNetCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run(); // default when created automatically ; This is in Asp.Net Core 2.x, Creates Web host to run the Asp Net core web app
            /*Basically ASP.Net Core Web Application is a console application, when i close the browser tab, program stops automatically*/
            // Have renamed the wwwroot folder to root, no issues runs successfully

            /*Below is the code for creating web host in Asp.Net Core 1.x*/
            //var host = new WebHostBuilder() //Web Host Builder is the helper class helps to create and configure web host for the web application
            //    .UseKestrel() /*specify use kestrel as the web server to be used by the web host! Kestrel is an open source, cross-platform web server for Asp.Net Core, 
            //    Asp.Net Core can be a cross platform web application, so it can be used with any web server not only with IIS. Hence there will be an external web server IIS, Apache, Nginx
            //    etc., which will dispatch http requests to the internal web server Kestrel.*/
            //    .UseContentRoot(Directory.GetCurrentDirectory()) // specify the content root directory to be used by the web host, which contains the static/content files such as CSS,images,js files.
            //    .UseIISIntegration() //configures the port and the base path the server should listen on when running behind AspNetCoreModule 
            //    .UseStartup<Startup>() //specifies the start up type to be used by the web host
            //    .Build();//Builds an Iwebhost which hosts a web application

            //host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args) /* Web host is a static class which can be used for creating an instance of IWebhost and IWebhostbuilder with pre configured defaults.   
                                               CreateDefaultBuilder() creates the new instance of web host builder with preconfigured defaults, internally it configures Kestrel, IISIntegration and 
                                               other configurations*/
                .UseStartup<Startup>()
                .Build();
    }

    /*Following is the Source code for CreateDefaultBuilder method from github*/
    //public static IWebHostBuilder CreateDefaultBuilder(string[] args)
    //{
    //    var builder = new WebHostBuilder()
    //        .UseKestrel()
    //        .UseContentRoot(Directory.GetCurrentDirectory())
    //        .ConfigureAppConfiguration((hostingContext, config) =>
    //        {
    //            var env = hostingContext.HostingEnvironment;

    //            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    //                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

    //            if (env.IsDevelopment())
    //            {
    //                var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
    //                if (appAssembly != null)
    //                {
    //                    config.AddUserSecrets(appAssembly, optional: true);
    //                }
    //            }

    //            config.AddEnvironmentVariables();

    //            if (args != null)
    //            {
    //                config.AddCommandLine(args);
    //            }
    //        })
    //        .ConfigureLogging((hostingContext, logging) =>
    //        {
    //            logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    //            logging.AddConsole();
    //            logging.AddDebug();
    //        })
    //        .UseIISIntegration()
    //        .UseDefaultServiceProvider((context, options) =>
    //        {
    //            options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
    //        });

    //    return builder;
    //}
}
