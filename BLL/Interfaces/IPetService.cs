using BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPetService : ICrud<PetModel>
    {
        Task<IQueryable<PetModel>> GetUserPets(int userId);
    }
}
