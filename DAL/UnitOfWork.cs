using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPeopleContext _peopleDbContext;
        private IPeopleRepository _peopleRepository;
        private IPetRepository _petRepository;
        public IPeopleRepository PeopleRepository
        {
            get
            {
                if(_peopleRepository == null)
                {
                    _peopleRepository = new PeopleRepository(_peopleDbContext);
                }
                return _peopleRepository;
            }
        }
        public IPetRepository PetRepository
        {
            get
            {
                if (_petRepository == null)
                {
                    _petRepository = new PetRepository(_peopleDbContext);
                }
                return _petRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _peopleDbContext.SaveChangesAsync();
        }
    }
}
