using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.Events
{
    public class RadioButtonNameMessage
    {
      
            /// <summary>
            /// Test
            /// </summary>
            public string ButtonName { get; set; }
            public RadioButtonNameMessage(string buttonName)
            {
                ButtonName = buttonName;
            }
       
    }
}
