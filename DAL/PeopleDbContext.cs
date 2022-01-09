using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PeopleDbContext : DbContext, IPeopleContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
    }
}
