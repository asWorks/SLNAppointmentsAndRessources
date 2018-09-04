using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BehandlerPatientenTermin : INotifyPropertyChanged
    {

        public int Id { get; set; }

        public DateTime Datum { get; set; }

        public DateTime Uhrzeit { get; set; }


        public int BehandlerID { get; set; }

        public DateTime Termin { get; set; }

        public int MandantID { get; set; }

        public int RezeptID { get; set; }

        public bool istVergeben { get; set; }

        public bool istAusgefuehrt { get; set; }

        public bool test { get; set; }




        private int _PatientenID;
        public int PatientenID
        {
            get { return _PatientenID; }
            set
            {
                if (value != _PatientenID)
                {
                    _PatientenID = value;
                    OnPropertyChanged("PatientenID");
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
                    OnPropertyChanged("PatientenName");
                    //  isDirty = true;
                }
            }
        }


        public string BehandlerName { get; set; }


        public BehandlerPatientenTermin()
        {

        }

        public BehandlerPatientenTermin(DateTime termin, int behandlerID,
                                        int patientenID, string behandlerName, string patientenName,
                                        int mandantID, int rezeptID,bool ist_vergeben,bool ist_ausgefuehrt )
        {

            Termin = termin;
            BehandlerID = behandlerID;
            PatientenID = patientenID;
            BehandlerName = behandlerName;
            PatientenName = patientenName;
            MandantID = mandantID;
            RezeptID = rezeptID;
            this.istVergeben =ist_vergeben;
            this.istAusgefuehrt = ist_ausgefuehrt;

        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
