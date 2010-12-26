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
        #region Private
        /// <summary>
        /// The Netduino's analog readings are 0 - 1023 and with a AREF of 3.3volts that ends up being this per volt value
        /// </summary>
        private const double VOLTS_PER_ANALOG_TICK = 0.0032258064516129;

        /// <summary>
        /// The LV-MaxSonar's AN pin is 9.8 millivolts per inch
        /// </summary>
        private const double VOLTS_PER_INCH = 0.0098;

        private OutputPort _rx;
        private AnalogInput _an;
        private bool _calibration = true;
        private int _reading;
        #endregion

        #region ctor
        public LVMaxSonar(Cpu.Pin rxPin, Cpu.Pin anPin)
        {
            _rx = new OutputPort(rxPin, false);
            _an = new AnalogInput(anPin);
        }
        #endregion

        #region Properties
        /// <summary>
        /// The raw result of a range read
        /// </summary>
        public int Range
        {
            get { return _reading; }
        }

        /// <summary>
        /// The result of a range read in inches
        /// </summary>
        public int Inches
        {
            get
            {
                return Convert(Range);
            }
        }
        #endregion

        #region Public operations
        public void Read()
        {
            // If this is the first time then the time for the read is 100 msec instead of 50 msec
            int time = 50;
            if (_calibration)
                time = 100;

            // Command a range reading
            _rx.Write(true);

            Thread.Sleep(time);
            
            // Stop the range reading
            _rx.Write(false);

            // Read the analog pin that is the result of the range reading
            _reading = _an.Read();

            _calibration = false;
        }
        #endregion

        #region Private operations
        private int Convert(int range)
        {
            int inches = 0;
            double temp = double.Parse(range.ToString());
            inches = (int)((temp * VOLTS_PER_ANALOG_TICK) / VOLTS_PER_INCH);
            return inches;
        }
        #endregion

    }
}
