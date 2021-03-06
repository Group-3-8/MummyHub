using FagElGamousExcavation.Data;
using FagElGamousExcavation.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FagElGamousExcavation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<INDIContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:MummyHubDbConnection"]));

            services.AddDbContext<IdentityContext>(opts =>
                opts.UseSqlServer(Configuration[
                    "ConnectionStrings:IdentityConnection"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    }));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

            services.Configure<IdentityOptions>(opts => {
                opts.Password.RequiredLength = 10;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
            });

            services.ConfigureApplicationCookie(opts =>
            {
                opts.Cookie.Name = ".AspNetCore.Identity.Application";
                opts.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                opts.SlidingExpiration = true;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("pagenum",
                    "AllData/{pagenum}",
                    new { Controller = "AllData", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            IdentitySeedData.CreateAdminAccount(app.ApplicationServices, Configuration);
        }
    }
}








// Just in case everything goes wrong:
//using FagElGamousExcavation.Data;
//using FagElGamousExcavation.Models;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FagElGamousExcavation
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; set; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(
//                    Configuration.GetConnectionString("DefaultConnection")));

//            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//            //    .AddEntityFrameworkStores<ApplicationDbContext>();
//            services.AddControllersWithViews();
//            services.AddRazorPages();

//            services.AddDbContext<IdentityContext>(opts =>
//                opts.UseSqlServer(Configuration[
//                    "ConnectionStrings:IdentityConnection"],
//                    sqlServerOptionsAction: sqlOptions =>
//                    {
//                        sqlOptions.EnableRetryOnFailure();
//                    }));

//            services.AddIdentity<IdentityUser, IdentityRole>()
//                .AddEntityFrameworkStores<IdentityContext>();

//            services.Configure<IdentityOptions>(opts => {
//                opts.Password.RequiredLength = 6;
//                opts.Password.RequireNonAlphanumeric = false;
//                opts.Password.RequireLowercase = false;
//                opts.Password.RequireUppercase = false;
//                opts.Password.RequireDigit = false;
//                opts.User.RequireUniqueEmail = true;
//                opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
//            });
//        }


//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseDatabaseErrorPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllerRoute(
//                    name: "default",
//                    pattern: "{controller=Home}/{action=Index}/{id?}");
//                endpoints.MapRazorPages();
//            });

//            IdentitySeedData.CreateAdminAccount(app.ApplicationServices, Configuration);
//        }
//    }
//}

