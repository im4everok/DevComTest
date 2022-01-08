using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IPeopleContext _peopleDbContext;
        public PeopleRepository(IPeopleContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public async Task AddAsync(Person entity)
        {
            await _peopleDbContext.Set<Person>().AddAsync(entity);
        }

        public void Delete(Person entity)
        {
            _peopleDbContext.Set<Person>().Remove(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var person = await _peopleDbContext.Set<Person>().FindAsync(id);
            _peopleDbContext.Set<Person>().Remove(person);
        }

        public IQueryable<Person> FindAll()
        {
            return _peopleDbContext.Set<Person>();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var p = await _peopleDbContext.Set<Person>().FindAsync(id);
            return await _peopleDbContext.Set<Person>().FindAsync(id);
        }

        public void Update(Person entity)
        {
            _peopleDbContext.Set<Person>().Update(entity);
        }
    }
}
