using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesExample.Models
{
    public interface IAutoService
    {
        Task<bool> AddAsync(Auto auto);
        Task<bool> UpdateAsync(Auto auto);
        Task<bool> RemoveAsync(Auto auto);

        Task<Auto> FindAsync(long? id);
        Task<Auto> GetRandomAsync();

        DbSet<Auto> Autos { get; }



    }
}
