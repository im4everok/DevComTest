using BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPersonService : ICrud<PersonDto>
    {
        Task AddAsync(PersonDto model);
        Task AddPetToPersonAsync(int ownerId, PetDto model);
        Task<int> GetPersonPetCountAsync(int personId);
        IQueryable<PersonDto> GetPeopleByName(string personName);
    }
}
