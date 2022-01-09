using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IPeopleContext _peopleDbContext;
        public PersonRepository(IPeopleContext peopleDbContext)
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
            return _peopleDbContext.Set<Person>().Include(x => x.Pets);
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _peopleDbContext.Set<Person>().FindAsync(id);
        }

        public void Update(Person entity)
        {
            _peopleDbContext.Set<Person>().Update(entity);
        }
    }
}
