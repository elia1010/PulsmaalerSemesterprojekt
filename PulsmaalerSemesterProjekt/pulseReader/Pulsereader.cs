using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RPI;
using RPI.Controller;
using RPI.Display;
using RPI.Heart_Rate_Monitor;
using RPI.IO;

namespace Pulsmåler_Semesterprojekt
{
    public class Pulsereader
    {
        private DateTime startTime;
        private DateTime stopTime;
        private int numberOfPulses;
        private int calculatedPulse;
        private Puls pulseNumber;
        private TimeSpan timeSpan;

        public Pulsereader(RPi rpi)
        {
            pulseNumber = new Puls(rpi);
            startTime = new DateTime();
            stopTime = new DateTime();
            numberOfPulses = new int();
            calculatedPulse = new int();
            
        }

        public void startReadPulse()
        {
            pulseNumber.StartPuls();
        }
        
        


        public void setNumberOfPulse(int numberOfPulses)
        {
            this.numberOfPulses = numberOfPulses;
        }

        public Measurements ReadPulse(DateTime startTime, DateTime stopTime, string patientName)
        {
            this.startTime = startTime;
            this.stopTime = stopTime;

            //startTime = DateTime.Now;

            double tid;
            //ny variable hvor jeg gemmer min timeSpan
            timeSpan = stopTime.Subtract(startTime);
            tid = Convert.ToDouble(timeSpan.TotalSeconds);

           

            calculatedPulse = Convert.ToInt16(numberOfPulses / tid * 60);
            //numberOfPulses / (int)timeElapsed * 60 anden mulighed kaldet casting.

            Measurements measurement1 = new Measurements(startTime, stopTime, numberOfPulses, calculatedPulse, patientName);

            return measurement1;
        }
        
    }
}
