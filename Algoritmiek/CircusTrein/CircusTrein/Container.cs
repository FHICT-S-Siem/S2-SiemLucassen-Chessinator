using System.Collections.Generic;
using System.Linq;

namespace CircusTrein
{
    public class Container
    {
        // Maxcapacity of the container is 10.
        public int MaxCapacity = 10;

        // Readonly so the object can only be set once  in constructor.
        private readonly List<Animal> _animals;
        public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();

        public Container(Animal animal)
        {
            _animals = new List<Animal> { animal };
        }

        public bool TryAddAnimal(Animal animal)
        {
            // Checks if animal is equal or greater than 10 
            if (_animals.Sum(anml => (int)anml.AnimalSize) + (int)animal.AnimalSize > MaxCapacity)
            {
                return false;
            }

            // Checks if the animal is carnivore
            if (animal.AnimalType.Equals(AnimalType.Carnivore))
            {
                // Checks if there is already a carnivore in the container
                if (_animals.Exists(anml => anml.AnimalType.Equals(AnimalType.Carnivore)))
                {
                    return false;
                }

                // Checks if the animal is equal or smaller than any animal(herbivore) inside.
                if (_animals.Any(anml => (int)anml.AnimalSize <= (int)animal.AnimalSize))
                {
                    return false;
                }
            }
            
            // Check if there is a carnivore in the container and checks if its greater than or equal to the size of the selected animal.
            else if (_animals.Exists(anml => anml.AnimalType.Equals(AnimalType.Carnivore) && (int)anml.AnimalSize >= (int)animal.AnimalSize))
            {
                return false;
            }
            _animals.Add(animal);
            return true;
        }
    }
}
