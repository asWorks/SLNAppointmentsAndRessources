using Caliburn.Micro;
using MySQL_Dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{



   
    public class TestViewModel:Screen
    {

            


        private ObservableCollection<pat5> _PatientenAuswahl;
        public ObservableCollection<pat5> PatientenAuswahl
        {
            get { return _PatientenAuswahl; }
            set
            {
                if (value != _PatientenAuswahl)
                {
                    _PatientenAuswahl = value;
                    NotifyOfPropertyChange(() => PatientenAuswahl);
                    //  isDirty = true;
                }
            }
        }



        private string _PatientenName;
        public string PatientenName
        {
            get { return _PatientenName; }
            set
            {
                if (value != _PatientenName)
                {
                    _PatientenName = value;
                    NotifyOfPropertyChange(() => PatientenName);
                    //  isDirty = true;
                }
            }
        }


        private string _Id;
        public string Id
        {
            get { return _Id; }
            set
            {
                if (value != _Id)
                {
                    _Id = value;    
                    NotifyOfPropertyChange(() => Id);
                    //  isDirty = true;
                }
            }
        }


        private string _Behandler;
        public string Behandler
        {
            get { return _Behandler; }
            set
            {
                if (value != _Behandler)
                {
                    _Behandler = value;
                    NotifyOfPropertyChange(() => Behandler);
                    //  isDirty = true;
                }
            }
        }


        public TestViewModel()
        {

            var repo = new Dal.Repositories.GenericRepository<MySQL_Dal.pat5>(new MySQL_Dal.GuesterModel());

            var patient = repo.FindBy(n => n.V_NAME == "Arpad").SingleOrDefault();

            var patienten = repo.FindBy(n => n.N_NAME.StartsWith("S")).ToList();
            PatientenAuswahl = new ObservableCollection<pat5>(patienten);

            var pat = patienten.Select  (x => new {Nachname = x.N_NAME });
                
            



            PatientenName = string.Format("Herr {0},{1}",patient.N_NAME,patient.V_NAME) ;
            Behandler = "Anja";
            Id = "TXXX antwortet nicht";
        }



    }
}
