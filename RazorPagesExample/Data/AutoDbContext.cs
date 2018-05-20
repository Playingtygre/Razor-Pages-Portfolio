using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesExample.Models;

namespace RazorPagesExample.Data
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }

        public AutoDbContext(DbContextOptions<AutoDbContext> options) : base(options)
        {
        }

    }
}
