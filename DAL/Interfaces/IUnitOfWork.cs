using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IPeopleRepository PeopleRepository { get; }
        IPetRepository PetRepository { get; }
        Task<int> SaveAsync();
    }
}
