using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AWSHubService.Interfaces;
using AWSHubService.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Routing;
using AWSHubService.Data;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using AWSHubService.Controllers;
using Serilog;

namespace AWSHubService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.RollingFile("log-{Date}.txt")
            .CreateLogger();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<ITodoRepository, TodoRepository>();
            //add dependancy injection to ApplicationModelProvider to pass Logger and Config objects to RequireClientCert attribute
            services.AddTransient<IApplicationModelProvider, ApplicationModelProvider>();
            services.AddDbContext<ClientDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*
            services.Configure<IISOptions>(options => {
                options.AutomaticAuthentication = false;
                options.ForwardClientCertificate = true;
                options.ForwardWindowsAuthentication = false;
            });
            */

            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();

            app.UseMvc();

            //app.Use(ChangeContextToHttps);
            //app.UseKestrelHttps(certificate);
            //app.UseDeveloperExceptionPage();
            /*
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id}");
            });
            */
            app.UseMvcWithDefaultRoute();
        }
    }
}
