using BLL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Interfaces
{
    public interface IPetService : ICrud<PetDto>
    {
        IQueryable<PetDto> GetUserPets(int userId);
    }
}
