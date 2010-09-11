using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace TimerExample
{
    public class Program
    {
        public static void Main()
        {
            Debug.Print("Kicking off the timer");
            Debug.Print(DateTime.Now.ToString());

            // Call the OnTimer method after 5 seconds have expired and then repeat every 10 seconds
            Timer timer = new Timer(new TimerCallback(OnTimer), null, 5000, 10000);

            Debug.Print("Waiting for the timer to expire");
            Debug.Print(DateTime.Now.ToString());
            Thread.Sleep(25000);

            Debug.Print("Killing the timer");
            timer.Dispose();
            Thread.Sleep(Timeout.Infinite);
        }



        public static void OnTimer(object state)
        {
            Debug.Print("Timout Triggered");
            Debug.Print(DateTime.Now.ToString());
        }
    }
}
