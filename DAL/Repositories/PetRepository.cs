using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly IPeopleContext _peopleDbContext;

        public PetRepository(IPeopleContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public async Task AddAsync(Pet entity)
        {
            await _peopleDbContext.Set<Pet>().AddAsync(entity);
        }

        public void Delete(Pet entity)
        {
            _peopleDbContext.Set<Pet>().Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var pet = await _peopleDbContext.Set<Pet>().FindAsync(id);
            _peopleDbContext.Set<Pet>().Remove(pet);
        }

        public IQueryable<Pet> FindAll()
        {
            return _peopleDbContext.Set<Pet>();
        }

        public async Task<Pet> GetByIdAsync(int id)
        {
            return await _peopleDbContext.Set<Pet>().FindAsync(id);
        }

        public void Update(Pet entity)
        {
            _peopleDbContext.Set<Pet>().Update(entity);
        }
    }
}
