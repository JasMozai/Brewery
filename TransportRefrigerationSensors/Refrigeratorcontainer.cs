using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRefrigerationSensors
{
    public class RefrigeratorContainer
    {
        public string Identifier { get; set; }
        public IThermostatSensor ThermostatSensor { get; private set; }

        public RefrigeratorContainer(IThermostatSensor sensor, string identifier)
        {
            Identifier = identifier;
            ThermostatSensor = sensor;
            ThermostatSensor.SetContentTempCheckPolicy(GetContainerTemperature);
            Contents = new List<RefrigerationContent>();
        }

        public RefrigeratorContainer(string identifier) : this(new DefaultThermostatSensor(), identifier)
        {
        }

        public List<RefrigerationContent> Contents { get; private set; }

        public RefrigeratorContainer LoadContent(RefrigerationContent content)
        {
            Contents.Add(content);
            return this;
        }

        public int GetContainerTemperature()
        {
            var currentTemperature = ThermostatSensor.GetCurrentTemperature();
            bool isCrossingTemperature = Contents.Any(content => currentTemperature < content.GetLowerTemperature() || currentTemperature > content.GetUpperTemperature());
            if (isCrossingTemperature)
            {
                ThermostatSensor.SendAlert(this, currentTemperature);
            }
            else
            {
                ThermostatSensor.DisplayTemp(this, currentTemperature);
            }
            return ThermostatSensor.GetCurrentTemperature();
        }
    }

}
