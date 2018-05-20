using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext (DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio.Models.Project> Project { get; set; }
    }
}
