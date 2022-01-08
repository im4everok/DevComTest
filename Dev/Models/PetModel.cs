using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Models
{
    public class PetModel
    {
        public PersonDto Owner { get; set; }
        public PetDto Pet { get; set; }
    }
}
