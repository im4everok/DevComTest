using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IPersonRepository PeopleRepository { get; }
        IPetRepository PetRepository { get; }
        Task<int> SaveAsync();
    }
}
