using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane.Controllers
{
    public class BreedController
    {
        public List<Breed> GetAllBreeds()
        {
            using (AnimalsContext _animalContext = new AnimalsContext())
            {
                return _animalContext.Breeds.ToList();
            }
        }

        public string GetBreedById(int id)
        {
            using (AnimalsContext _animalContext = new AnimalsContext())
            {
                return _animalContext.Breeds.Find(id).Name;
            }
        }
    }
}
