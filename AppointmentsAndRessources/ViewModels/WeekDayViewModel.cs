using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsAndRessourses.Models;

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


        private ObservableCollection<TerminData> _Termine;
        public ObservableCollection<TerminData> Termine
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





            string[] Behandler = { "Mariann", "Anja", "Alex" };

            Termine = new ObservableCollection<TerminData>();

            for (int i = 1; i < 23; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var td = new TerminData { PatientenName = "Freier Termin", Behandler = Behandler[j], ID = i.ToString() + " - " + j.ToString(), Termin = new DateTime(2017, 11, 3, i, 0, 0) };
                    Termine.Add(td);
                }
            }


        }

     public void addTerminData()
        {
            var x = new TerminData { PatientenName = "Marc Marcieu", Behandler = "Anja", Termin = new DateTime(2017, 11, 6, 11, 25, 0), ID = "125" };
            Termine.Add(x);
        }


    }
}
