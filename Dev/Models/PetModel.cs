using BLL.Models;

namespace Dev.Models
{
    public class PetModel
    {
        public PersonDto Owner { get; set; }
        public PetDto Pet { get; set; }
    }
}
