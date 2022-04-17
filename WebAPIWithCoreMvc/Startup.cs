using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebAPIWithCoreMvc.ApiServices;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Handlers;

namespace WebAPIWithCoreMvc
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
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddScoped<AuthTokenHandler>();
            #region HttpClient
            services.AddHttpClient<IAuthApiService, AuthApiService>(opt =>
               {
                   opt.BaseAddress = new Uri("http://localhost:16148/api/");
               });
            services.AddHttpClient<IUserApiService, UserApiService>(opt =>
            {
                opt.BaseAddress = new Uri("http://localhost:16148/api/");
            }).AddHttpMessageHandler<AuthTokenHandler>();
            #endregion

            #region Cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   opt =>
                   {
                       opt.LoginPath = "/Admin/Auth/Login";
                       opt.ExpireTimeSpan = TimeSpan.FromDays(60);
                       opt.SlidingExpiration = true;
                       opt.Cookie.Name = "mvccookie";
                   }); 
            #endregion
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
            }

            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    areaName:"Admin",
                    name: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
