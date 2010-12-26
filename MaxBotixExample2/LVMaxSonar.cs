using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace MaxBotixExample2
{
    public class LVMaxSonar
    {
        private OutputPort _rx;
        private AnalogInput _an;
        private bool _calibration = true;
        private int _reading;

        public LVMaxSonar(Cpu.Pin rxPin, Cpu.Pin anPin)
        {
            OutputPort _rx = new OutputPort(rxPin, false);
            AnalogInput _an = new AnalogInput(anPin);
        }

        public void Read()
        {
            // If this is the first time then
            int time = 50;
            if (_calibration)
                time = 100;

            _rx.Write(true);

            Thread.Sleep(time);
            
            _rx.Write(false);

            _reading = _an.Read();

            _calibration = false;
        }

        public int Range
        {
            get { return _reading; }
        }

    }
}
