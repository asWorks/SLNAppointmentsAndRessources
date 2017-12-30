using AppointmentsAndRessourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{
   public class ShellViewModel:ViewModelBase

    {


        private ObservableCollection<WeekDayViewModel> _Wochentage;
        public ObservableCollection<WeekDayViewModel> Wochentage
        {
            get { return _Wochentage; }
            set
            {
                if (value != _Wochentage)
                {
                    _Wochentage = value;
                    OnPropertyChanged("Wochentage");
                    //  isDirty = true;
                }
            }
        }


        public ShellViewModel()
        {

            Wochentage = new ObservableCollection<WeekDayViewModel>();
            for (int i = 0; i < 20; i++)
            {
                var wt = new WeekDayViewModel();
                wt.Datum = DateTime.Now.AddDays(i).ToString();
                Wochentage.Add(wt);
            }
        }



    }
}
