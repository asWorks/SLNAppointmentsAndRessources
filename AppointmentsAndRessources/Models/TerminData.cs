using AppointmentsAndRessources.ViewModels;
using AppointmentsAndRessourses.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace AppointmentsAndRessourses.Models
{

   

    public class TerminData
    {

        public TerminData()
        {
           
        }

        public string PatientenName { get; set; }       
        public string Behandler { get; set; }

        public DateTime Termin { get; set; }

        public string ID { get; set; }





      

        public TerminDataViewModel GetViewModel()
        {

            var vm = new TerminDataViewModel { PatientenName = this.PatientenName, Behandler = this.Behandler, Termin = this.Termin, ID = this.ID };
            return vm;
        }
     
    }
}