using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircusTrein.Test
{
    [TestClass]
    public class TrainTest
    {
        [TestMethod]
        public void TestAddAnimalsToContainer()
        {
            //Arrange
            Train t = new Train();

            //Act


            //Assert

            //False, no container
            Assert.IsFalse(t.AddAnimalToTrain("Herbivore", "Medium"));
            Assert.IsTrue(t.AddAnimalToTrain("Herbivore", "Small"));
            Assert.IsTrue(t.AddAnimalToTrain("Herbivore", "Small"));
            Assert.IsTrue(t.AddAnimalToTrain("Herbivore", "Large"));

            //First container filled up, should return false because the previous container has reached maxcapacity
            Assert.IsFalse(t.AddAnimalToTrain("Herbivore", "Small"));
            Assert.IsFalse(t.AddAnimalToTrain("Herbivore", "Medium"));

        }

    }
}
