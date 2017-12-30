using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsAndRessourses.Models;
using AppointmentsAndRessources.ViewModels;
using AppointmentsAndRessources.HelperClasses;
using Caliburn.Micro;

namespace AppointmentsAndRessourses.ViewModels
{
    public class WeekDayViewModel : Screen
    {





        private string _Datum;
        public string Datum
        {
            get { return _Datum; }
            set
            {
                if (value != _Datum)
                {
                    _Datum = value;
                    NotifyOfPropertyChange(() => Datum);
                    //  isDirty = true;
                }
            }
        }

        public RelayCommand ShowAllTermine { get; set; }
        public RelayCommand ShowTermineMariann { get; set; }
        public RelayCommand ShowTermineMaggie { get; set; }
        public RelayCommand ShowTermineAnja { get; set; }


        public List<TerminDataViewModel> AlleTermine { get; set; }


        private ObservableCollection<TerminDataViewModel> _Termine;
        public ObservableCollection<TerminDataViewModel> Termine
        {


            get { return _Termine; }
            set
            {
                if (value != _Termine)
                {
                    _Termine = value;
                    NotifyOfPropertyChange(() => Termine);
                    //  isDirty = true;
                }
            }
        }





        public WeekDayViewModel()
        {
          
            AddTermine();

            ShowAllTermine = new RelayCommand(Param => Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine), x=>true);
            ShowTermineMariann = new RelayCommand(Param => Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.Behandler == "Mariann")), x => true);
            ShowTermineMaggie = new RelayCommand(Param => Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.Behandler == "Maggie")), x => true);
            ShowTermineAnja= new RelayCommand(Param => Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.Behandler == "Anja")), x => true);

        }

        private void AddTermine()
        {
            string[] Behandler = { "Mariann", "Anja", "Alex", "Maggie", "Kyra" };

            Termine = new ObservableCollection<TerminDataViewModel>();
            AlleTermine = new List<TerminDataViewModel>();

            var t = new DateTime(2017, 11, 13, 8, 0, 0);

            for (int i = 1; i < 20; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var td = new TerminDataViewModel { PatientenName = "Freier Termin", Behandler = Behandler[j], ID = i.ToString() + " - " + j.ToString(), Termin = t };
                    //Termine.Add(td);
                    AlleTermine.Add(td);
                    t = t.AddDays(1);
                }


                t = t.AddMinutes(30);
            }

            Termine = new ObservableCollection < TerminDataViewModel > (AlleTermine.Where(n => n.Behandler == "Alex"));

        }

        public void addTerminData()
        {
            var x = new TerminDataViewModel { PatientenName = "Marc Marcieu", Behandler = "Anja", Termin = new DateTime(2017, 11, 6, 11, 25, 0), ID = "125" };
            Termine.Add(x);
        }


    }
}
