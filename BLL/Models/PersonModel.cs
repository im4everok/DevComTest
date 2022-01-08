using System.Collections.Generic;

namespace BLL.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PetModel> Pets { get; set; }
    }
}