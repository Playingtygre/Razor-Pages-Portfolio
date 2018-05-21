using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesExample.Data;

namespace RazorPagesExample.Models
{
    public class AutoService : IAutoService
    {
        private readonly AutoDbContext _autoDbContext;
        private readonly ILogger<IAutoService> _logger;

        private readonly Random _random;

        public AutoService(AutoDbContext autoDbContext, ILogger<AutoService> logger)
        {
            _autoDbContext = autoDbContext;
            _logger = logger;
            _random = new Random();
        }

        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _autoDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unable to update", args: null);
                return false;
            }
            return true;
        }

        public DbSet<Auto> Autos => _autoDbContext.Autos;

        public async Task<bool> AddAsync(Auto auto)
        {
            if (auto != null)
            {
                await Autos.AddAsync(auto);
                return await SaveChangesAsync();
            }
            return false;
        }

        public async Task<Auto> FindAsync(long? id) =>
            id.HasValue ? await Autos.FindAsync(id.Value) : null;


        public async Task<Auto> GetRandomAsync() =>
            await Autos.Skip(_random.Next(await Autos.CountAsync()))
                .FirstOrDefaultAsync();



        public async Task<bool> RemoveAsync(Auto auto)
        {
            if (auto != null)
            {
                Autos.Remove(auto);
                return await SaveChangesAsync();
            }

            return false;
        }

        public async Task<bool> UpdateAsync(Auto auto)
        {
            if (auto != null)
            {
                Autos.Update(auto);
                return await SaveChangesAsync();
            }

            return false;
        }


    }
}
