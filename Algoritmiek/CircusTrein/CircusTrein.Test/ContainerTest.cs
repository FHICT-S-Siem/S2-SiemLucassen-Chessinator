using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrein.Test
{
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void TryAddAnimal_AddsAnimalToContainer_ShouldHaveAnimalInList()
        {
            //Arrange - The animals get initialized with their values
            Animal a = new Animal(AnimalSize.Large, AnimalType.Herbivore);
            Animal b = new Animal(AnimalSize.Medium, AnimalType.Herbivore);

            // Adds animal a to container.
            Container container = new Container(a);

            //Act
            // Tries to add animal b to container.
            container.TryAddAnimal(b);

            //Assert
            //Check if both animals are in container.
            Assert.IsTrue(container.Animals.Contains(a));
            Assert.IsTrue(container.Animals.Contains(b));
        }

        [TestMethod]
        public void AddsAnimalToContainer_ChecksOverMaximumCapacity_ShouldResultFalse()
        {
            //Arrange - The animals get initialized with their values
            Animal a = new Animal(AnimalSize.Large, AnimalType.Herbivore);
            Animal b = new Animal(AnimalSize.Medium, AnimalType.Carnivore);
            Animal c = new Animal(AnimalSize.Large, AnimalType.Herbivore);
            // Adds animal a to container.
            Container container = new Container(a);

            //Act
            // Adds animal b to container because there is a larger sized Animal in the same container so the carnivore doesn't eat it
            // and maximum-capacity has not been reached.
            container.TryAddAnimal(b);

            //Assert
            // Adds animal c to container.
            // Should result in False, because the maximum capacity has been reached within the same container.
            Assert.AreEqual(container.TryAddAnimal(c), false);
            
        }

        [TestMethod]
        public void AddsAnimalToContainer_ChecksCarnivoreEatingBehaviour_ShouldResultFalse()
        {
            //Arrange - The animals get initialized with their values
            Animal a = new Animal(AnimalSize.Large, AnimalType.Herbivore);
            Animal b = new Animal(AnimalSize.Medium, AnimalType.Carnivore);
            Animal c = new Animal(AnimalSize.Small, AnimalType.Herbivore);
            // Adds animal a to container.
            Container container = new Container(a);

            //Act
            // Adds animal b to container because there is a larger sized Animal in the same container so the carnivore doesn't eat it
            // and maximum-capacity has not been reached.
            container.TryAddAnimal(b);

            //Assert
            
            // Tries to add animal c to container
            // Should result in False, because there is a medium sized carnivore which will eat the smaller sized herbivore animal.
            Assert.AreEqual(container.TryAddAnimal(c), false);
        }

        
    }
}
