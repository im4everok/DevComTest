using Microsoft.EntityFrameworkCore;
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
