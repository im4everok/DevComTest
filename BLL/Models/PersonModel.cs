using System.Collections.Generic;

namespace BLL.Interfaces
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PetModel> Pets { get; set; }
    }
}