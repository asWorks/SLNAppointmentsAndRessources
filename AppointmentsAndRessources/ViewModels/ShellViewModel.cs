using AppointmentsAndRessourses.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{
   public class ShellViewModel: Conductor<object>
    {



        public TermineEditViewModel termineEditViewModel { get; set; }



        public ShellViewModel()
        {

            //  ActivateItem(new TermineEditViewModel());
            termineEditViewModel = new TermineEditViewModel();
          
        }



        public void Termine()
        {
            ActivateItem( termineEditViewModel);
        }


        public void Test()
        {
            ActivateItem(new TestViewModel());
        }

    }
}
