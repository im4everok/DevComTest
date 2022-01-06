using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public interface IPeopleContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<T> Set<T>() where T : class;
    }
}
