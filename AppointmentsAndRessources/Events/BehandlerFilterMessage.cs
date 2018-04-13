using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.Events
{
   public class BehandlerFilterMessage
    {
        /// <summary>
        /// Test
        /// </summary>
        public int Message { get; set; }
        public BehandlerFilterMessage(int message)
        {
            Message = message;
        }
    }
}
