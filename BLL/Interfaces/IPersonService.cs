using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPersonService : ICrud<PersonModel>
    {
        Task<IQueryable<PersonModel>> GetPersonPetCountAsync();
    }
}
