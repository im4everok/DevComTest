using System.Collections.Generic;

namespace BLL.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PetDto> Pets { get; set; }
    }
}