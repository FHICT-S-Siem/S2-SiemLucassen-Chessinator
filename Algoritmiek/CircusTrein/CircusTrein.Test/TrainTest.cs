using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CircusTrein.Test
{
    [TestClass]
    public class TrainTest
    {
        [TestMethod]
        public void AfterTheFirstContainerReachesMaximumCapacity_ANewContainerShouldBeCreated_Successfully()
        {
            //Arrange
            Train t = new Train();
            t.AddAnimalToTrain(new Animal(AnimalSize.Small, AnimalType.Herbivore));
            t.AddAnimalToTrain(new Animal(AnimalSize.Small, AnimalType.Herbivore));
            t.AddAnimalToTrain(new Animal(AnimalSize.Medium, AnimalType.Herbivore));
            t.AddAnimalToTrain(new Animal(AnimalSize.Large, AnimalType.Herbivore));


            //Act
            // First container is full, makes new container because the first container has reached maximum-capacity
            t.AddAnimalToTrain(new Animal(AnimalSize.Medium, AnimalType.Herbivore));

            //Assert
            Assert.AreEqual(2, t.Containers.Count);
        }
    }
}
