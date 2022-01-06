using BLL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IPetService : ICrud<PetModel>
    {
        IEnumerable<PetModel> GetUserPets(int userId);
    }
}
