using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.HelperClasses
{
    public class TempHelperFunctions
    {

        private static int counter = 0;

        public static int GetCounter()
        {
            counter++;
            return counter;
        }
    }
}
