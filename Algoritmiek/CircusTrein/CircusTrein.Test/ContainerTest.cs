using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrein.Test
{
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void TestAddAnimalsToContainer()
        {
            //Assert
            Animal a = new Animal(AnimalSize.Large, AnimalType.Herbivore);
            Animal b = new Animal(AnimalSize.Large, AnimalType.Herbivore);
            Animal c = new Animal(AnimalSize.Small, AnimalType.Herbivore);
            Container container = new Container(a);

            //Act


            //Assert
            // True
            Assert.AreEqual(container.TryAddAnimal(b), true);
            
            // False
            Assert.AreEqual(container.TryAddAnimal(c), false);
        }      
    }
}
