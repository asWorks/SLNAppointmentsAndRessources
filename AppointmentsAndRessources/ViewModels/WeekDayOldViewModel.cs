using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsAndRessourses.Models;

namespace AppointmentsAndRessourses.ViewModels
{
   public class WeekDayOldViewModel:ViewModelBase
    {




        private ObservableCollection<TerminData>[] _Terminlisten;
        public ObservableCollection<TerminData>[] Terminlisten
        {
            get { return _Terminlisten; }
            set
            {
                if (value != _Terminlisten)
                {
                    _Terminlisten = value;
                    OnPropertyChanged("Terminlisten");
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



        private ObservableCollection<TerminData> _TermineDienstag;
        public ObservableCollection<TerminData> TermineDienstag
        {
            get { return _TermineDienstag; }
            set
            {
                if (value != _TermineDienstag)
                {
                    _TermineDienstag = value;
                    OnPropertyChanged("TermineDienstag");
                    //  isDirty = true;
                }
            }
        }



        private ObservableCollection<TerminData> _TermineMittwoch;
        public ObservableCollection<TerminData> TermineMittwoch
        {
            get { return _TermineMittwoch; }
            set
            {
                if (value != _TermineMittwoch)
                {
                    _TermineMittwoch = value;
                    OnPropertyChanged("TermineMittwoch");
                    //  isDirty = true;
                }
            }
        }



        private ObservableCollection<TerminData> _TermineDonnerstag;
        public ObservableCollection<TerminData> TermineDonnerstag
        {
            get { return _TermineDonnerstag; }
            set
            {
                if (value != _TermineDonnerstag)
                {
                    _TermineDonnerstag = value;
                    OnPropertyChanged("TermineDonnerstag");
                    //  isDirty = true;
                }
            }
        }


        private ObservableCollection<TerminData> _TermineFreitag;
        public ObservableCollection<TerminData> TermineFreitag
        {
            get { return _TermineFreitag; }
            set
            {
                if (value != _TermineFreitag)
                {
                    _TermineFreitag = value;
                    OnPropertyChanged("TermineFreitag");
                    //  isDirty = true;
                }
            }
        }

        public WeekDayOldViewModel()
        {

          


            Termine = new ObservableCollection<TerminData>
            { new TerminData { PatientenName="Arpad Stöver", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"}

            };


            TermineDienstag = new ObservableCollection<TerminData>
            { new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2" },
                 new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"},
                new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2" },
                 new TerminData { PatientenName="Helmut Kahl", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"}

            };

            TermineMittwoch = new ObservableCollection<TerminData>
            { new TerminData { PatientenName="Gerd My", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"}

            };

            TermineDonnerstag = new ObservableCollection<TerminData>
            { new TerminData { PatientenName="Christine WInterfeld", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
                new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
                new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"}

            };

            //TermineFreitag = new ObservableCollection<TerminData>
            //{ new TerminData { PatientenName="Jennifer Walter", Behandler="Anja",Termin=new DateTime(2017,11,6,11,25,0),ID="1"},
            //    new TerminData { PatientenName = "Knut Kummert", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 11, 50, 0),ID="2"},
            //    new TerminData { PatientenName = "Georg Witt", Behandler = "Mariann Fiedrich", Termin = new DateTime(2017, 11, 6, 12, 20, 0),ID="2"}

            //};


            string[] Behandler = { "Mariann", "Anja", "Alex" };

            TermineFreitag = new ObservableCollection<TerminData>();

            for (int i = 1; i < 23; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var td = new TerminData { PatientenName = "Freier Termin", Behandler = Behandler[j], ID = i.ToString() + " - " + j.ToString(), Termin = new DateTime(2017, 11, 3, i, 0, 0) };
                    TermineFreitag.Add(td);
                }
            }


        }

     public void addTerminData()
        {
            var x = new TerminData { PatientenName = "Marc Marcieu", Behandler = "Anja", Termin = new DateTime(2017, 11, 6, 11, 25, 0), ID = "125" };
            Terminlisten[1].Add(x);
        }


    }
}
