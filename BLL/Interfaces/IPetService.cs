using BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPetService : ICrud<PetDto>
    {
        Task AddAsync(PetDto model, int ownerId);
        IQueryable<PetDto> GetUserPets(int userId);
        IQueryable<PetDto> GetUserPetsByPetName(int userId, string name);
    }
}
