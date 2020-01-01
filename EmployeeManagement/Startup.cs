using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;
        
        public Startup(IConfiguration config)
        {
            _config = config;  
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option=>option.EnableEndpointRouting=false).AddXmlSerializerFormatters();
            
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            /* 
             * ---Middleware UseDefaultFile
             * DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
             defaultFilesOptions.DefaultFileNames.Clear();
             defaultFilesOptions.DefaultFileNames.Add("foo.html");

             app.UseDefaultFiles(defaultFilesOptions);

             app.UseStaticFiles();
             */

            /* 
             * ---Middleware UseFileServer
             * 
            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(fileServerOptions);
*/
           
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("MW3: Request handled and response produced");
                logger.LogInformation("MW3: Request handled and response produced");
            });



            //************************************************************//
            /*  app.Use(async (context, next) =>
              {
                  logger.LogInformation("MW1: Incoming Request");
                  await next();
                  logger.LogInformation("MW1: Outgoing Response");
              });

              app.Use(async (context, next) =>
              {
                  logger.LogInformation("MW2: Incoming Request");
                  await next();
                  logger.LogInformation("MW2: Outgoing Response");
              });

              app.Run(async (context) =>
              {
                  await context.Response.WriteAsync("MW3: Request handled and response produced");
                  logger.LogInformation("MW3: Request handled and response produced");
              });
          */
            //************************************************************//



          /*  app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World");
                });
            });
            */
         
        }
    }
}
