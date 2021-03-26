using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein
{
    public class Container
    {
        public int MaxCapacity = 10;

        private readonly List<Animal> _animals;

        public IReadOnlyCollection<Animal> Animals => _animals.AsReadOnly();

        public Container(Animal animal)
        {
            _animals = new List<Animal> { animal };
        }

        public bool TryAddAnimal(Animal animal)
        {
            // is groter dan 10
            if (_animals.Sum(anml => (int)anml.AnimalSize) + (int)animal.AnimalSize > MaxCapacity)
            {
                return false;
            }

            // eet het dier vlees
            if (animal.AnimalType.Equals(AnimalType.Carnivore))
            {
                // kijkt of er een vlees in zit
                if (_animals.Exists(anml => anml.AnimalType.Equals(AnimalType.Carnivore)))
                {
                    return false;
                }

                // kijkt of het dier kleiner of gelijk is aan het dier
                if (_animals.Any(anml => (int)anml.AnimalSize <= (int)animal.AnimalSize))
                {
                    return false;
                }
            }
            
            // kijkt of er een vlees in zit en kijkt of het groter of gelijk is dan het geselecteerde dier.
            else if (_animals.Exists(anml => anml.AnimalType.Equals(AnimalType.Carnivore) && (int)anml.AnimalSize >= (int)animal.AnimalSize))
            {
                return false;
            }
            _animals.Add(animal);
            return true;
        }

    }
}
