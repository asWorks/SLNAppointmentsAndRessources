using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.Events
{
    public class RequestPatientenInfoMessage
    {


        public int TerminId { get; set; }
                                          
        public RequestPatientenInfoMessage(int terminId)
        {
            TerminId = terminId;
        }
    }
}
