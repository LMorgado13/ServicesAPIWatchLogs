using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace WatchDog.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
           
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            //  Register the Swagger generator, defining 1 or more Swagger documents
            //  Se comenta para trabajar con control de versiones
            services.AddSwaggerGen(c =>
            {
                //    c.SwaggerDoc("v1", new OpenApiInfo
                //    {
                //        Version = "v1",
                //        Title = "MorganSolution Technology Services API Market",
                //        Description = "A simple example ASP.NET Core Web API",
                //        TermsOfService = new Uri("https://MorganSolution.com/terms"),
                //        Contact = new OpenApiContact
                //        {
                //            Name = "Luis Morgado",
                //            Email = "lois_morgado@hotmail.com",
                //            Url = new Uri("https://MorganSolution.com/contact")
                //        },
                //        License = new OpenApiLicense
                //        {
                //            Name = "Use under LICX",
                //            Url = new Uri("https://MorganSolution.com/licence")
                //        }
                //    });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);


                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securityScheme, new List<string>() { } }
                });
            });
            return services;
        }
    }
}
