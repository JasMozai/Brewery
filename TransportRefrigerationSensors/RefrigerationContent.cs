using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRefrigerationSensors
{
    public abstract class RefrigerationContent
    {
        //The container can load content other than Beer as well
        public abstract int GetUpperTemperature();
        public abstract int GetLowerTemperature();

    }
}
