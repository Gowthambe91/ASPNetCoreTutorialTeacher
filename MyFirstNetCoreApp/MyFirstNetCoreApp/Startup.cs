using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyFirstNetCoreApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /*This is where we register the Dependent classes with IoC container. Dependancy injection is heavily used by the Asp.Net Core Architecture. After registering we can use them anywhere 
             * in the application, we just have to include it in the parameter of the constructor of the class, IoC container will automatically inject the dependant class.
             Asp.Net Core refers dependant classes as service, so whenever we read service , consider it as a class going to be used in some other class.
             ConfigureServices method includes IServiceCollection parameter to register services to the IoC container.*/

            services.Add(new ServiceDescriptor(typeof(ILog), new MyConsoleLogger())); /*Registering the ILog type for the class MyConsoleLogger, so whenever/wherever ILog type is referred
                                                                                        MyConsoleLogger will be injected, whether in property/method/constructor.*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) //These parameters are framework services(classes) injected by built in IoC container.
        {
            /*Configure is the place where we can configure application request pipeline using IApplicationBuilder instance that is provided by the built in IoC container. Asp.Net Core introduced the
             * Middleware concept which helps to define the request pipeline  which will be executed on every request. So we include only those necessary middleware components , thus increase the 
             performance of the application. */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        /*At runtime Configure Services method will be called before Configure method -  so that all the dependancies are registered before that may be used in the configure method. */
    }
}
