using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportRefrigerationSensors.Program;

namespace TransportRefrigerationSensors
{
    public interface IThermostatSensor
    {
        int GetCurrentTemperature();
        void SetContentTempCheckPolicy(Func<int> contentTempPolicy);
        void SendAlert(RefrigeratorContainer faultyContainer, int currentTemperature);
        void SensorCheck(object sender, System.Timers.ElapsedEventArgs e);
        void DisplayTemp(RefrigeratorContainer container, int currentTemperature);
    }
}
