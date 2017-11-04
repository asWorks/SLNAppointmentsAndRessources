using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsAndRessourses.Models;
using AppointmentsAndRessources.ViewModels;

namespace AppointmentsAndRessourses.ViewModels
{
   public class WeekDayViewModel:ViewModelBase
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
                    OnPropertyChanged("Datum");
                    //  isDirty = true;
                }
            }
        }




       

        private ObservableCollection<TerminDataViewModel> _Termine;
        public ObservableCollection<TerminDataViewModel> Termine
        {


            get { return _Termine; }
            set
            {
                if (value != _Termine)
                {
                    _Termine = value;
                    OnPropertyChanged("Termine");
                    //  isDirty = true;
                }
            }
        }



      

        public WeekDayViewModel()
        {
            //Termine = new ObservableCollection<TerminData> { new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
            //    new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
            //    new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2" },
            //     new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
            //    new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
            //    new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"},
            //    new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
            //    new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
            //    new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2" },
            //     new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
            //    new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
            //    new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"}

            //};






            AddTermine();

        }

        private void AddTermine()
        {
            string[] Behandler = { "Mariann", "Anja", "Alex", "Maggie", "Kyra" };

            Termine = new ObservableCollection<TerminDataViewModel>();

            for (int i = 1; i < 20; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var td = new TerminDataViewModel { PatientenName = "Freier Termin", Behandler = Behandler[j], ID = i.ToString() + " - " + j.ToString(), Termin = DateTime.Now.AddDays(j) };
                    Termine.Add(td);
                }
            }
        }

        public void addTerminData()
        {
            var x = new TerminDataViewModel { PatientenName = "Marc Marcieu", Behandler = "Anja", Termin = new DateTime(2017, 11, 6, 11, 25, 0), ID = "125" };
            Termine.Add(x);
        }


    }
}
