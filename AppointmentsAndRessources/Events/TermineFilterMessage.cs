using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.Events
{
    public class TermineFilterMessage
    {
        public enum EnumFilterMessage
        {
            Alle,Vergebene,Freie
        }

        public EnumFilterMessage TerminFilter { get; set; }

        public TermineFilterMessage(EnumFilterMessage terminfilter)
        {
            TerminFilter = terminfilter;
        }
    }
}
