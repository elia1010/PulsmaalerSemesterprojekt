 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPI;
using RPI.Controller;
using RPI.Display;
using RPI.Heart_Rate_Monitor;
using RPI.IO;

namespace Pulsmåler_Semesterprojekt
{
    public class Measurements
    {
        private DateTime startTime;
        private DateTime stopTime;
        private int numberOfPulses;
        private int calculatedPulse;
        private string patientName;
        


        public Measurements(DateTime startTime, DateTime stopTime, int numberOfPulses, int calculatedPulse, string patientName)
        {
            this.startTime = startTime;
            this.stopTime = stopTime;
            this.numberOfPulses = numberOfPulses;
            this.calculatedPulse = calculatedPulse;
            this.patientName = patientName;
        }

        public int getCalculatedPulse()
        {
            return calculatedPulse;
        }
        public override string ToString()
        {
            return $"{patientName}        {calculatedPulse}     {startTime}   ";
        }

    }
}

