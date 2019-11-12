using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace SportStore1.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            //if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A bost for one person",
                        Category = "WaterSports", Price = 275
                    },
                    new Product
                    {
                        Name = "LifeJacket",
                        Description = "Protective and fashionable",
                        Category = "WaterSports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playig field a professional touch",
                        Category = "WaterSports",
                        Price = 35.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-Packed 35,000-seat stadium",
                        Category = "WaterSports",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Chess Board",
                        Description = "Game for the family",
                        Category = "Chess",
                        Price = 75
                    }

            ) ;
                 context.SaveChanges();
        }
        }
    }
}
