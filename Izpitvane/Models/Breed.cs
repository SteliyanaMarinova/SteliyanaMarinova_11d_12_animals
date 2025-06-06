using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane
{
    public class Breed
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public ICollection<Animal> Breeds { get; set; }
    }
}
