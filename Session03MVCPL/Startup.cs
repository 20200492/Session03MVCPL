using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Session03MVCEDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session03MVCPL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // Register Built-In Services Required by MVC
            ///services.AddControllers();          // Register Built-In Services Required by API
            ///services.AddRazorPages();           // Register Built-In Services Required by Razor-Pages
            ///services.AddMvc();                  // Register Built-In Services Required by MVC,API and Razor-Pages

            ///services.AddTransient<DbContextApplications>(); // CLR Creat More Than Object From DbContextApplications Per Request ==> This Lead To May be Open More Than Connection In Same Request
            ///services.AddScoped<DbContextApplications>();    // CLR Creat One Object From DbContextApplications Per Request

            //services.AddSingleton<DbContextApplications>(); // CLR Creat One Object From DbContextApplications Per Session => The BestCase 
            //services.AddSingleton<DbContextOptions>();     // CLR Creat One Object From DbContextOptions Per Session => The BestCase  

            services.AddDbContext<DbContextApplications>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
