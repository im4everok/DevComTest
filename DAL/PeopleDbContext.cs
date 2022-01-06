using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
