using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TerminData
    {


      

        public int ID { get; set; }

        public DateTime Termin { get; set; }

        public virtual ICollection<BehandlerPatientenTermin> BehandlerPatientenTermine { get; set; }

        public TerminData(DateTime termin)
        {
            Termin = termin;
        }

        public TerminData()
        {

        }

        public TerminData(DateTime termin, List<BehandlerPatientenTermin> termine)
        {
            if (BehandlerPatientenTermine == null)
            {
                BehandlerPatientenTermine = new List<BehandlerPatientenTermin>();
            }
            Termin = termin;
            BehandlerPatientenTermine = termine;
        }

        public TerminData(int id,DateTime termin, List<BehandlerPatientenTermin> termine)
        {

            ID = id;
           

            if (BehandlerPatientenTermine == null)
            {
                BehandlerPatientenTermine = new List<BehandlerPatientenTermin>();
            }
            Termin = termin;
            BehandlerPatientenTermine = termine;
        }

    }
}
