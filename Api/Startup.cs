using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Aplication.Command.Show;
using Aplication.Command.Add;
using Aplication.Command.Edit;
using Aplication.Command.Delete;
using EfCommands.EfAdd;
using EfCommands.EfEdit;
using EfCommands.EfDelete;
using EfCommands;
using EfDataAccess;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.IO;

namespace Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AuctionContext>();

            //Category
            services.AddTransient<IShowCategories, EfShowCategories>();
            services.AddTransient<IShowCategory, EfShowCategory>();
            services.AddTransient<IShowCategoryGood, EfShowCategoryGood>();
            services.AddTransient<IAddCategory, EfAddCategory>();
            services.AddTransient<IEditCategory, EfEditCategory>();
            services.AddTransient<IDeleteCategory, EfDeleteCategory>();

            //Goods
            services.AddTransient<IShowGoodsCategory, EfShowGoodsCategory>();
            services.AddTransient<IShowGood, EfShowGood>();
            services.AddTransient<IAddGood, EfAddGood>();
            services.AddTransient<IEditGood, EfEditGood>();
            services.AddTransient<IDeleteGood, EfDeleteGood>();
            

            //Auctions
            services.AddTransient<IAddAuction, EfAddAuction>();
            services.AddTransient<IShowAuctionGoodAuctioner, EfShowAuctionGoodAuctioner>();
            services.AddTransient<IShowAuction, EfShowAuction>();
            services.AddTransient<IEditAuction, EfEditAuction>();
            services.AddTransient<IDeleteAuction, EfDeleteAuction>();

            //Auctioners
            services.AddTransient<IAddAuctioner, EfAddAuctioner>();
            services.AddTransient<IShowAuctioners, EfShowAuctioners>();
            services.AddTransient<IShowAuctioner, EfShowAuctioner>();
            services.AddTransient<IEditAuctioner, EfEditAuctioner>();
            services.AddTransient<IDeleteAuctioner, EfDeleteAuctioner>();

            //Roles
            services.AddTransient<IShowRoles, EfShowRoles>();
            services.AddTransient<IShowRole, EfShowRole>();
            services.AddTransient<IAddRole, EfAddRole>();
            services.AddTransient<IEditRole, EfEditRole>();
            services.AddTransient<IDeleteRole, EfDeleteRole>();

            //Images
            services.AddTransient<IShowImages, EfShowImages>();
            services.AddTransient<IAddImage, EfAddImage>();
            services.AddTransient<IShowImage, EfShowImage>();
            services.AddTransient<IDeleteImage, EfDeleteImage>();

            //paginate Auction
            services.AddTransient<IPaginateAuctions, EfPaginateAuction>();


            
            // Register the Swagger generator, defining 1 or more Swagger documents
         
                services.AddSwaggerGen(c =>
                {

                    // Set the comments path for the Swagger JSON and UI.
                    c.SwaggerDoc("v1", new Info
                    {
                        Version = "v1",
                        Title = "Auction API",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = "None",
                        
                    });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });
          
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();
        }
    }
}
