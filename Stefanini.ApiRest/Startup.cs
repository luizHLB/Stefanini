using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Stefanini.ApiRest.Extensions;
using Stefanini.ApiRest.MiddleWare;
using Stefanini.Domain.Configuration;
using Stefanini.IoC;
using System.Globalization;
using System.IO.Compression;
using System.Linq;

namespace Stefanini.ApiRest
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.RegisterModules(services);
            services.MapModulesContabil();
            services.AddSwaggerDocumentation("Stefanini");
            services.Configure<AplicationSettings>(Configuration.GetSection("Configuration"));

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            ConfigureFormatters(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseStaticFiles();

            app.UsePathBase("/Stefanini");
            app.Use((context, next) =>
            {
                context.Request.PathBase = "/Stefanini";
                return next();

            });

            app.UseSwaggerDocumentation(GetType(), "Stefanini.ApiRest", "Stefanini.ApiRest", "Stefanini.ApiRest");

            app.UseCors(options =>
               options.AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin());

            app.UseMiddleware(typeof(ExceptionHandler));

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseResponseCompression();
            
        }

        private static void ConfigureFormatters(IServiceCollection services)
        {
            services.AddMvc()
                   .AddNewtonsoftJson(options =>
                   {
                       options.SerializerSettings.Formatting = Formatting.Indented;
                       options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                       options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                       options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                       options.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss";
                       options.SerializerSettings.Culture = CultureInfo.CurrentCulture;
                   });
        }
    }
}
