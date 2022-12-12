using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Pulsmåler_Semesterprojekt
{
    public class ConvertToBCD
    {        

        public static int pulseToBCD(int tal)
        {
            int bcdResult = 0;
            int shift = 0;


            while (tal > 0)
            {
                bcdResult |= (tal % 10) << (shift++ * 4);
                tal /= 10;
            }
            

            return bcdResult;
        }
    }
}
