using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesExample.Models;


namespace RazorPagesExample.Data
{
    public static class SeedAuto
    {
        public static Auto[] AutosExample => new Auto[]
        {
            new Auto()
            {
                Name = "Ford",
                ImageUrl ="https://placeimg.com/640/480/",
                Summary="Funny Looking Car"

            },

            new Auto()
            {
                Name = "Toyota",
                ImageUrl ="https://placeimg.com/640/480/",
                Summary="Funny Looking Car"

            },
        };



        public static async Task Initialize(IServiceProvider services)
        {
            using (AutoDbContext context = new AutoDbContext(
                services.GetRequiredService<DbContextOptions<AutoDbContext>>()))
            {
                if (await context.Autos.AnyAsync())
                {
                    return;
                }

                await context.Database.EnsureCreatedAsync();

                await context.Autos.AddRangeAsync(AutosExample);

                await context.SaveChangesAsync();
            }
             
        }


    }
}
