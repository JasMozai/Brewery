using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportRefrigerationSensors
{
    class Program
    {
        static void Main(string[] args)
        {

            Truck truck1 = new Truck(2000);//Set timer frequency to check temperature

            Beer beer1 = new Beer(4, 6);
            Beer beer2 = new Beer(5, 6);
            Beer beer3 = new Beer(4, 7);
            Beer beer4 = new Beer(6, 8);
            Beer beer5 = new Beer(3, 5);

            //The initial temperature setting to make sure container's temperature setting within the containing beers' temperature ranges.
            //Set temperature to 3C and Load beer5 in container 1
            RefrigeratorContainer container1 = new RefrigeratorContainer("1");
            container1
                .LoadContent(beer5);

            //Set temperature to 4C and Load beer1, beer3, beer5 in container 2
            RefrigeratorContainer container2 = new RefrigeratorContainer("2");
            container2
                .LoadContent(beer1)
                .LoadContent(beer3)
                .LoadContent(beer5);

            //Set temperature to 5C and Load beer1, beer2, beer3, beer5 in container 3
            RefrigeratorContainer container3 = new RefrigeratorContainer("3");
            container3
                .LoadContent(beer1)
                .LoadContent(beer2)
                .LoadContent(beer3)
                .LoadContent(beer5);

            //Set temperature to 6C and Load beer1, beer2, beer3, beer4 in container 4
            RefrigeratorContainer container4 = new RefrigeratorContainer("4");
            container4
                .LoadContent(beer1)
                .LoadContent(beer2)
                .LoadContent(beer3)
                .LoadContent(beer4);

            //Set temperature to 7C and Load beer3, beer4 in container 5
            RefrigeratorContainer container5 = new RefrigeratorContainer("5");
            container5
                .LoadContent(beer3)
                .LoadContent(beer4);

            //Set temperature to 8C and Load beer4 in container 6
            RefrigeratorContainer container6 = new RefrigeratorContainer("6");
            container6
                .LoadContent(beer4);

            truck1
                .Load(container1)
                .Load(container2)
                .Load(container3)
                .Load(container4)
                .Load(container5)
                .Load(container6);

            Console.ReadLine();
        }
    }
}
