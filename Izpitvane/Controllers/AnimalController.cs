using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izpitvane.Controllers
{
    public class AnimalController
    {
        public Animal Get(int id)
        {
            using (AnimalsContext _AnimalsContext = new AnimalsContext())
            {
                Animal findedAnimal = _AnimalsContext.Animals.Find(id);
                if (findedAnimal != null)
                {
                    _AnimalsContext.Entry(findedAnimal).Reference(x => x.Breeds).Load();
                }
                return findedAnimal;
            }
        }
        public List<Animal> GetAll()
        {
            using (AnimalsContext _AnimalsContext = new AnimalsContext())
            {
                return _AnimalsContext.Animals.Include("Breeds").ToList();
            }
        } 

        public void Create(Animal Animal)
        {
            using (AnimalsContext _AnimalsContext = new AnimalsContext())
            {
                _AnimalsContext.Animals.Add(Animal);
                _AnimalsContext.SaveChanges();
            }
        }

        public void Update(int id, Animal Animal)
        {
            using (AnimalsContext _AnimalsContext = new AnimalsContext())
            {
                Animal findedAnimal = _AnimalsContext.Animals.Find(id);
                if (findedAnimal == null)
                {
                    return;
                }
                findedAnimal.Age = Animal.Age;
                findedAnimal.Name = Animal.Name;
                findedAnimal.Description = Animal.Description;
                findedAnimal.BreedId = Animal.BreedId;
                _AnimalsContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (AnimalsContext _AnimalsContext = new AnimalsContext())
            {
                Animal findedAnimal = _AnimalsContext.Animals.Find(id);
                _AnimalsContext.Animals.Remove(findedAnimal);
                _AnimalsContext.SaveChanges();
            }
        }
    }
}

