using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRefrigerationSensors
{
    public class Beer : RefrigerationContent
    {
        private int LowerTemp { get; set; }
        private int UpperTemp { get; set; }

        public Beer(int lowerTemp, int upperTemp)
        {
            LowerTemp = lowerTemp;
            UpperTemp = upperTemp;
        }
        public override int GetLowerTemperature()
        {
            return LowerTemp;
        }

        public override int GetUpperTemperature()
        {
            return UpperTemp;
        }
    }
}
