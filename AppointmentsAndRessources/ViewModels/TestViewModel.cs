using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{



   
    public class TestViewModel:Screen
    {


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
            PatientenName = "Herr Müller-Lüdenscheidt";
            Behandler = "Anja";
            Id = "TXXX antwortet nicht";
        }



    }
}
