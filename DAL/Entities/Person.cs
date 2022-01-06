using System.Collections.Generic;

namespace DAL.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
