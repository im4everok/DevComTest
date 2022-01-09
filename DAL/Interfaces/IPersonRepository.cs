using DAL.Entities;
using DAL.Repositories;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
