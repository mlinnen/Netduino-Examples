using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace MaxBotixExample
{
    public class Program
    {
        /// <summary>
        /// This program shows how to use a MaxBotix LV-MaxSonar sensor
        /// </summary>
        public static void Main()
        {
            // Default the rx pin to low to keep the sensor off
            OutputPort rx = new OutputPort(Pins.GPIO_PIN_D0, false);
            AnalogInput an = new AnalogInput(Pins.GPIO_PIN_A5);
            int range;

            // Wait at least 250 milliseconds for the sensor to power up
            Thread.Sleep(250);

            // Turn on the sensor
            rx.Write(true);

            // Wait 100 Milliseconds for the calibration cycle to complete
            Thread.Sleep(100);

            // Turn off the sensor
            rx.Write(false);

            while (true)
            {
                // Turn on the sensor
                rx.Write(true);

                // Wait 50 Milliseconds
                Thread.Sleep(50); 

                // Turn off the sensor
                rx.Write(false);

                // Read the result
                range = an.Read();

                // Print the result
                Debug.Print(range.ToString());
            }


        }

    }
}
