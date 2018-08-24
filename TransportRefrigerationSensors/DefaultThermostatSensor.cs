using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportRefrigerationSensors.Program;

namespace TransportRefrigerationSensors
{
    public class DefaultThermostatSensor : IThermostatSensor
    {
        private static Random rnd = new Random();

        private Func<int> ContentTempPolicy { get; set; }
        public DefaultThermostatSensor()
        {
        }

        public void SetContentTempCheckPolicy(Func<int> contentTempPolicy)
        {
            ContentTempPolicy = contentTempPolicy;
        }

        public void SensorCheck(object sender, System.Timers.ElapsedEventArgs e)
        {
            ContentTempPolicy();
        }

        public int GetCurrentTemperature()
        {
            return rnd.Next(0, 30);
        }

        public void SendAlert(RefrigeratorContainer faultyContainer, int currentTemperature)
        {
            Console.WriteLine("Hi Baz. Faulty Container:" + faultyContainer.Identifier + "@" + currentTemperature);
        }

        public void DisplayTemp(RefrigeratorContainer container, int currentTemperature)
        {
            Console.WriteLine("Hi Baz. Container:" + container.Identifier + "@" + currentTemperature);
        }
    }
}
