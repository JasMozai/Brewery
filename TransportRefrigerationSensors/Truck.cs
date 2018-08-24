using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRefrigerationSensors
{
    public class Truck
    {
        public System.Timers.Timer TruckTimer { get; set; }
        public List<RefrigeratorContainer> Containers { get; private set; }

        public Truck(int timerFrequency)
        {
            TruckTimer = new System.Timers.Timer(timerFrequency);
            TruckTimer.Enabled = true;
            TruckTimer.AutoReset = true;
            Containers = new List<RefrigeratorContainer>();
        }

        public Truck Load(RefrigeratorContainer container)
        {
            Containers.Add(container);
            TruckTimer.Elapsed += container.ThermostatSensor.SensorCheck;
            return this;
        }

    }
}
