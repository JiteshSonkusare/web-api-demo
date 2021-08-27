using DemoWebApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace DemoWebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        internal static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
           {
               var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
               foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
               {
                   if (!assembly.IsDynamic)
                   {
                       var xmlFile = $"{assembly.GetName().Name}.xml";
                       var xmlPath = Path.Combine(baseDirectory, xmlFile);
                       if (File.Exists(xmlPath))
                       {
                           c.IncludeXmlComments(xmlPath);
                       }
                   }
               }

               c.SwaggerDoc("v1", new OpenApiInfo
               {
                   Version = "v1",
                   Title = "Demo Web API",
                   License = new OpenApiLicense
                   {
                       Name = "MIT License",
                       Url = new Uri("https://opensource.org/licenses/MIT")
                   }
               });
           });
        }

        internal static Product GetApplicationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection(nameof(Product));
            services.Configure<Product>(applicationSettingsConfiguration);
            return applicationSettingsConfiguration.Get<Product>();
        }
    }
}
