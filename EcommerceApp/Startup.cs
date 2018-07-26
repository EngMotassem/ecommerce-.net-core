using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

using System.Threading.Tasks;
using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Services.Interfaces;
using EcommerceApp.Services.Reposotories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using EcommerceApp.Services.Helpers;

namespace EcommerceApp
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

            services.AddCors(options => options.AddPolicy("CorsPolicy", p => p.AllowAnyOrigin()
                                                             .AllowAnyMethod()
                                                              .AllowAnyHeader()));
                                                              
           // services.AddCors();

            services.AddMvc();


            services.AddAutoMapper();


            services.AddTransient<Seed>();



            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionString:Default"]));

           services.AddIdentity<Customer, ApplicationRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:token").Value);




            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });



            services.AddScoped<ICategory, CategoryRepo>();
            services.AddScoped<ISubCategory, SubCatRepo>();
            services.AddScoped<ICustomer, CustomerRepo>();
          //  services.addaut
            services.AddScoped<IDating, DatingRepo>();



            services.AddScoped<IProduct, ProductRepo>();

            services.AddSingleton<IOrder, OrderRepo>();


            services.AddScoped<IOrderLine, OrderLineRepo>();

            services.AddScoped<ICartItem, CartItemRepo>();

            services.AddTransient<IPicture, PictureRepo>();


            services.AddScoped<IAuth, AuthRepo>();

            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));









        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
        {

            // builder.WithOrigins("http://localhost:4200")

            /*   app.UseCors(x => x.WithOrigins("http://localhost:4200")
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials());
                   */

            app.UseCors("CorsPolicy");



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }



           // seeder.SeedUsers();

            // global cors policy




            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "AdminAreaRoute",
                    template: "{area:exists}/{controller=Products}/{action=Index}/{id?}"
                   


                    );

                routes.MapRoute(
                    name: "AdminAreaCategory",
                    template: "{area:exists}/{controller=Products}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "AdminAreaUsers",
                    template: "{area:exists}/{controller=Products}/{action=Index}/{id?}");
            });

       
        }
    }
}
