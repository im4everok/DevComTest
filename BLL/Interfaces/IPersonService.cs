using BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPersonService : ICrud<PersonModel>
    {
        Task<int> GetPersonPetCountAsync(int personId);
        IQueryable<PersonModel> GetPeopleByName(string personName);
    }
}
