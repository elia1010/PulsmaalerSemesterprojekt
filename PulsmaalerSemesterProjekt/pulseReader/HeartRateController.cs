using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RPI;
using RPI.Controller;
using RPI.Display;
using RPI.Heart_Rate_Monitor;
using RPI.IO;

namespace Pulsmåler_Semesterprojekt
{
    public class HeartRateController
    {
        private RPi rpi;
        private Key startButton;
        private Key stopButton;
        private PWM pwm;
        private Puls pulseNumber;
        private Pulsereader pulseReader;
        private SevenSeg sevenseg;
        private DateTime startTime;
        private DateTime stopTime;
        public List<Measurements> Measurements { get; }

        public HeartRateController()
        {
            rpi = new RPi();
            startButton = new Key(rpi, Key.ID.P1);
            stopButton = new Key(rpi, Key.ID.P2);
            pwm = new PWM(rpi);
            pulseNumber = new Puls(rpi);
            sevenseg = new SevenSeg(rpi);
            startTime = new DateTime();
            stopTime = new DateTime();
            pulseReader = new Pulsereader(rpi);
            Measurements = new List<Measurements>();
        }

        public void reset()
        {
            sevenseg.Close_SevenSeg();
        }
        public void Start(string patientName)
        {

            sevenseg.Init_SevenSeg();
            while(!startButton.isPressed())
            {
                rpi.wait(30);
            }
            // Kører for evigt til startbutton bliver trykket hvor efter koden går videre.
            //venter i 30 ms før den kører igen
            rpi.wait(300);

            pwm.InitPWM();
            pwm.SetPWM(50);
            startTime = DateTime.Now;
            pulseNumber.StartPuls();

            while (!startButton.isPressed())
            {
                rpi.wait(30); 
            }
            pwm.SetPWM(25);
            stopTime = DateTime.Now;
            int readpulse = pulseNumber.ReadPuls();
            //pulseReader.setNumberOfPulse(5); // Test før diode læser.  
            pulseReader.setNumberOfPulse(readpulse); // Readpulse stopper og læser på puls antallet.
            
            Measurements reading = pulseReader.ReadPulse(startTime, stopTime, patientName);
 
             Measurements.Add(reading);

            int last = Measurements.Last().getCalculatedPulse();
           

            sevenseg.Disp_SevenSeg((short)ConvertToBCD.pulseToBCD(reading.getCalculatedPulse()));

            //MessageBox.Show(Convert.ToString(last));

            //Anvender Casting til at konvertere noget til noget andet f.eks en Int til en short:)
            
            

        }

    }

    
}
