using System;
using System.Collections.Generic;
using System.Linq;

namespace CircusTrein
{
    public class Train
    {
        public IList<Container> Containers { get; }

        public Train()
        {
            Containers = new List<Container>();
        }

        public bool AddAnimalToTrain(string type, string size)
        {
            AnimalType changedType;
            AnimalSize changedSize;
            if (type == "Herbivore")
            {
                changedType = AnimalType.Herbivore;
            }
            else if (type == "Carnivore")
            {
                changedType = AnimalType.Carnivore;
            }
            else
            {
                throw new ArgumentException("Incorrect type");
            }

            if (size == "Small") 
            {
                changedSize = AnimalSize.Small;
            }
            else if (size == "Medium")
            {
                changedSize = AnimalSize.Medium;
            }
            else if (size == "Large")
            {
                changedSize = AnimalSize.Large;
            }
            else
            {
                throw new ArgumentException("Incorrect size");
            }

            Animal animal = new Animal(changedSize, changedType);
            if (TryToAddAnimalToAnyContainer(animal))
            {
                Containers.Add(new Container(animal));
                return false;
            }
            else return true;
        }
        private bool TryToAddAnimalToAnyContainer(Animal animal) => Containers.Any(container => container.TryAddAnimal(animal));
    }
}
