using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportStore1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SportStore1
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)

        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
                (Configuration["Data:SportStoreProducts:ConnectionString"]
                )
            );
           
            services.AddMvc();
            services.AddTransient<IProductRepository, EFProductRepository>();
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseStatusCodePages();
                app.UseMvc(routes =>
                {
                    routes.MapRoute(name: "pagination",
                      template: "Products/Page{productPage}", 
                      defaults: new { Controller = "Product", Action ="List"});
                });
                SeedData.EnsurePopulated(app);
            }
                
        }
    }
}
