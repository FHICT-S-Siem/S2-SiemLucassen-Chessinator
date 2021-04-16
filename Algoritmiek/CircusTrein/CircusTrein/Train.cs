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

        public void AddAnimalToTrain(Animal animal)
        {
            if (!TryToAddAnimalToAnyContainer(animal))
            {
                Containers.Add(new Container(animal));
            }
        }
        private bool TryToAddAnimalToAnyContainer(Animal animal) => Containers.Any(container => container.TryAddAnimal(animal));
    }
}
