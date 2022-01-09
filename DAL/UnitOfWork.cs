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
        private IPersonRepository _peopleRepository;
        private IPetRepository _petRepository;
        public UnitOfWork(IPeopleContext peopleContext)
        {
            _peopleDbContext = peopleContext;
        }
        public IPersonRepository PeopleRepository
        {
            get
            {
                if(_peopleRepository == null)
                {
                    _peopleRepository = new PersonRepository(_peopleDbContext);
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
