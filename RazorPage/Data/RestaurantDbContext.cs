using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurant { get; set; }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            //this.EnsureSeedData also causes an error
            this.EnsureSeedData();

        }

    }
}
