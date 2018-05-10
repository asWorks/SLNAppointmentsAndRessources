using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TerminData
    {


        public TerminData()
        {

        }
        public int ID { get; set; }
        public int PatientenID { get; set; }

        public string PatientenName { get; set; }

        public string Memo { get; set; }

        public int BehandlerID { get; set; }

        public string Behandler { get; set; }

        public DateTime Termin { get; set; }

        public int Mandant { get; set; }

        public int RezeptID { get; set; }

        public bool istVergeben { get; set; }

        public bool istAusgeführt { get; set; }

        public bool  test { get; set; }




    }
}
