﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Aplication.Command.Show;
using Aplication.Command.Edit;
using Aplication.Command.Add;
using Aplication.Command.Delete;
using EfDataAccess;
using EfCommands.EfAdd;
using EfCommands.EfDelete;
using EfCommands.EfEdit;
using EfCommands;
namespace WebApplication
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AuctionContext>();

            services.AddTransient<IShowCategories, EfShowCategories>();
            services.AddTransient<IShowCategory, EfShowCategory>();
            services.AddTransient<IAddCategory, EfAddCategory>();
            services.AddTransient<IDeleteCategory, EfDeleteCategory>();


            services.AddTransient<IAddWebAuction, EfAddWAuction>();
            services.AddTransient<IShowAuctionGoodAuctioner, EfShowAuctionGoodAuctioner>();
            services.AddTransient<IShWebAuction, EfShWebAuction>();
            services.AddTransient<IEditAuction, EfEditAuction>();
            services.AddTransient<IDeleteAuction, EfDeleteAuction>();

            services.AddTransient<IShowAuctioners, EfShowAuctioners>();
            services.AddTransient<IShowGoodsCategory, EfShowGoodsCategory>();
            services.AddTransient<IEditAuction, EfEditAuction>();
           

            services.AddTransient<IShowImages, EfShowImages>();
            services.AddTransient<IAddImage, EfAddImage>();
            services.AddTransient<IShowImage, EfShowImage>();
            services.AddTransient<IDeleteImage, EfDeleteImage>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
