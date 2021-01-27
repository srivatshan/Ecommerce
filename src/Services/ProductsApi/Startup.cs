using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProductsApi.Data;
using ProductsApi.Data.Interface;
using ProductsApi.Data.Repository;
using ProductsApi.Model;

namespace ProductsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //            services.AddAuthentication(options =>
            //            {
            //                options.DefaultScheme = "cookie";
            //                options.DefaultChallengeScheme = "oidc";
            //            })
            //    .AddCookie("cookie")




            //.AddOpenIdConnect("oidc", options =>
            //    {
            //        options.Authority = "https://localhost:44366";
            //        options.ClientId = "ProductApi";
            //        options.ClientSecret = "SuperSecretPassword";

            //        options.ResponseType = "code";
            //        options.UsePkce = true;
            //        options.ResponseMode = "query";

            //        // options.CallbackPath = "/signin-oidc"; // default redirect URI

            //        // options.Scope.Add("oidc"); // default scope
            //        // options.Scope.Add("profile"); // default scope

            //        options.Scope.Add("api1.read");
            //        options.SaveTokens = true;
            //    });
            services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {

        options.ApiName = "api1";
        options.Authority = "https://localhost:44366";
    });
            //Connection String
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductDetails")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });
            //Registering swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ProductDetails API",
                    Description = "A simple example ASP.NET Core Web API",

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.  
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            //Swagger JSON endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          //  app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());



            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
