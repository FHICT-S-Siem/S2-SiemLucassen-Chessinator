using System.Collections.Generic;
using System.Linq;

namespace CircusTrein
{
    public class Train
    {

        // Readonly so the object can only be set once  in constructor.
        private readonly List<Container> _containers;
        public IReadOnlyCollection<Container> Containers => _containers.AsReadOnly();

        public Train()
        {
            _containers = new List<Container>();
        }

        public void AddAnimalToTrain(Animal animal)
        {
            // If animal does not fit in any existing container, a new container is created.
            if (!TryToAddAnimalToAnyContainer(animal))
            {
                _containers.Add(new Container(animal));
            }
        }
        // Tries to add an animal to any container, when true returns true.
        private bool TryToAddAnimalToAnyContainer(Animal animal) => _containers.Any(container => container.TryAddAnimal(animal));
    }
}
