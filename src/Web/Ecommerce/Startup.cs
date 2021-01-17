using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Infrastructure;
using Ecommerce.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce
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
          //  en you can update your authentication configuration to look like the following:

services.AddAuthentication(options =>
{
    options.DefaultScheme = "cookie";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("cookie")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:44366";
        options.ClientId = "oidcClient";
        options.ClientSecret = "SuperSecretPassword";

        options.ResponseType = "code";
        options.UsePkce = true;
        options.ResponseMode = "query";

        // options.CallbackPath = "/signin-oidc"; // default redirect URI

        // options.Scope.Add("oidc"); // default scope
        // options.Scope.Add("profile"); // default scope
        options.Scope.Add("api1.read");
        options.SaveTokens = true;
    });
            services.Configure<AppSettings>(Configuration);
            services.AddControllersWithViews();
            services.AddTransient<IHttpClient, CustomHttpClient>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IAccountService,AccountService>();
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "cookie";
            //})
            //.AddCookie("cookie");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            //});
        }
    }
}
