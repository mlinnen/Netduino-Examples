using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace MaxBotixExample2
{
    public class Program
    {
        public static void Main()
        {
            LVMaxSonar sensor = new LVMaxSonar(Pins.GPIO_PIN_D0, Pins.GPIO_PIN_A5);
            while (true)
            {  
                sensor.Read();
                Debug.Print(sensor.Inches.ToString());
                Thread.Sleep(100);
            }
        }
    }
}
