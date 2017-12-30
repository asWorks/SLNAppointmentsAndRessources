using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    class TerminData
    {


        public TerminData()
        {

        }

        public string PatientenName { get; set; }
        public string Behandler { get; set; }

        public DateTime Termin { get; set; }

        public string ID { get; set; }







        //public TerminDataViewModel GetViewModel()
        //{

        //    var vm = new TerminDataViewModel { PatientenName = this.PatientenName, Behandler = this.Behandler, Termin = this.Termin, ID = this.ID };
        //    return vm;
        //}
    }
}
