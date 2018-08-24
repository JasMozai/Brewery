using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransportRefrigerationSensors;

namespace TransportRefrigerationSensorsUnitTest
{
    [TestClass]
    public class TransportRefrigerationSensorsUnitTest
    {
        [TestMethod]
        public void LoadContent_CheckNumber()
        {
            var beer3 = new Beer(4, 7);
            var container1 = new RefrigeratorContainer("1");
                container1
                    .LoadContent(beer3)
                    .LoadContent(beer3);

            Assert.AreEqual(2,container1.Contents.Count);
        }

        [TestMethod]
        public void LoadContainer_CheckNumber()
        {
            var truck1 = new Truck(2000);
            var beer3 = new Beer(4, 7);
            var container1 = new RefrigeratorContainer("1");
            container1
                .LoadContent(beer3)
                .LoadContent(beer3);

            var container2 = new RefrigeratorContainer("2");
            container2
                .LoadContent(beer3);

            truck1
                .Load(container1)
                .Load(container2);
            Assert.AreEqual(2, truck1.Containers.Count);
        }

        [TestMethod]
        public void GetContainerTemperature_SendAlert()
        {
            Beer beer3 = new Beer(4, 7);
            Beer beer4 = new Beer(6, 8);
            //Beer beer5 = new Beer(3, 5);

            //The initial temperature setting to make sure container's temperature setting within the containing beers' temperature ranges.
            //Set temperature to 3C and Load beer5 in container 1

            var sensor = new Mock<IThermostatSensor>();
            sensor.Setup(d => d.GetCurrentTemperature()).Returns(5);

            var container1 = new RefrigeratorContainer(sensor.Object, "1");
            container1
                .LoadContent(beer3)
                .LoadContent(beer4);

            container1.GetContainerTemperature();

            sensor.Verify(x => x.SendAlert(container1, 5), Times.Once);
        }

        [TestMethod]
        public void GetContainerTemperature_DisplayTemp()
        {
            Beer beer3 = new Beer(4, 7);
            Beer beer4 = new Beer(6, 8);
            //Beer beer5 = new Beer(3, 5);

            //The initial temperature setting to make sure container's temperature setting within the containing beers' temperature ranges.
            //Set temperature to 3C and Load beer5 in container 1

            var sensor = new Mock<IThermostatSensor>();
            sensor.Setup(d => d.GetCurrentTemperature()).Returns(6);

            var container1 = new RefrigeratorContainer(sensor.Object, "1");
            container1
                .LoadContent(beer3)
                .LoadContent(beer4);

            container1.GetContainerTemperature();

            sensor.Verify(x => x.DisplayTemp(container1, 6), Times.Once);
        }

    }
}
