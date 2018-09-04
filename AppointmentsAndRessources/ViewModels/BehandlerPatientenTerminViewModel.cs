using Caliburn.Micro;
using Domain.Models;
using System;
using System.Windows.Media;

namespace AppointmentsAndRessources.ViewModels
{
    public class BehandlerPatientenTerminViewModel : Screen
    {

        #region "Constructors"

        BehandlerPatientenTermin bpt;

        public BehandlerPatientenTerminViewModel(BehandlerPatientenTermin model)
        {
            Termin = model.Termin;
            BehandlerID = model.BehandlerID;
            PatientenID = model.PatientenID;
            BehandlerName = model.BehandlerName;
            PatientenName = model.PatientenName;
            MandantID = model.MandantID;
            RezeptID = model.RezeptID;
            this.istVergeben = model.istVergeben;
            this.istAusgefuehrt = model.istAusgefuehrt;

            bpt = model;


        }


        #endregion

        #region "Properties"


        private DateTime _Termin;
        public DateTime Termin
        {
            get { return _Termin; }
            set
            {
                if (value != _Termin)
                {
                    _Termin = value;
                    bpt.Termin = value;
                    NotifyOfPropertyChange(() => Termin);
                    //  isDirty = true;
                }
            }
        }


        private int _BehandlerID;
        public int BehandlerID
        {
            get { return _BehandlerID; }
            set
            {
                if (value != _BehandlerID)
                {
                    _BehandlerID = value;
                    bpt.BehandlerID = value;
                    NotifyOfPropertyChange(() => BehandlerID);
                    //  isDirty = true;
                }
            }
        }


        private int _PatientenID;
        public int PatientenID
        {
            get { return _PatientenID; }
            set
            {
                if (value != _PatientenID)
                {
                    _PatientenID = value;
                    bpt.PatientenID = value;
                    NotifyOfPropertyChange(() => PatientenID);
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
                    bpt.PatientenName = value;
                    NotifyOfPropertyChange(() => PatientenName);
                    //  isDirty = true;
                }
            }
        }


        private string _BehandlerName;
        public string BehandlerName
        {
            get { return _BehandlerName; }
            set
            {
                if (value != _BehandlerName)
                {
                    _BehandlerName = value;
                    bpt.BehandlerName = value;
                    NotifyOfPropertyChange(() => BehandlerName);
                    //  isDirty = true;
                }
            }

        }


        private bool _istVergeben;
        public bool istVergeben
        {
            get { return _istVergeben; }
            set
            {
                if (value != _istVergeben)
                {
                    _istVergeben = value;
                    bpt.istVergeben = value;
                    NotifyOfPropertyChange(() => istVergeben);
                    //  isDirty = true;
                }
            }
        }


        private bool _istAusgefuehrt;
        public bool istAusgefuehrt
        {
            get { return _istAusgefuehrt; }
            set
            {
                if (value != _istAusgefuehrt)
                {
                    _istAusgefuehrt = value;
                    bpt.istAusgefuehrt = value;
                    NotifyOfPropertyChange(() => istAusgefuehrt);
                    //  isDirty = true;
                }
            }
        }


        private int _RezeptID;
        public int RezeptID
        {
            get { return _RezeptID; }
            set
            {
                if (value != _RezeptID)
                {
                    _RezeptID = value;
                    bpt.RezeptID = value;
                    NotifyOfPropertyChange(() => RezeptID);
                    //  isDirty = true;
                }
            }
        }


        private int _MandantID;
        public int MandantID
        {
            get { return _MandantID; }
            set
            {
                if (value != _MandantID)
                {
                    _MandantID = value;
                    bpt.MandantID = value;
                    NotifyOfPropertyChange(() => MandantID);
                    //  isDirty = true;
                }
            }
        }
        #endregion

        #region "Functions"
        public BehandlerPatientenTermin GetModel()
        {
            return bpt;
        }


        #endregion

        #region "UI Anpassungen"


        private Brush _BehandlerBackground;
        public Brush BehandlerBackground
        {
            get { return _BehandlerBackground; }
            set
            {
                if (value != _BehandlerBackground)
                {
                    _BehandlerBackground = value;
                    NotifyOfPropertyChange(() => BehandlerBackground);
                    //  isDirty = true;
                }
            }
        }


        private Brush _TerminBackground;
        public Brush TerminBackground
        {
            get { return _TerminBackground; }
            set
            {
                if (value != _TerminBackground)
                {
                    _TerminBackground = value;
                    NotifyOfPropertyChange(() => TerminBackground);
                    //  isDirty = true;
                }
            }
        }

        public void SetSelectedBrush(bool flag)
        {
            Brush bg;
            switch (flag)
            {
                case true:
                    {
                        bg = new SolidColorBrush(Colors.Yellow);
                        break;
                    }

                case false:
                    {
                        bg = new SolidColorBrush(Colors.White);
                        break;
                    }


                default:
                    {
                        bg = new SolidColorBrush(Colors.LightBlue);
                        break;
                    }
            }

            TerminBackground = bg;

        }
        public void SetBehandlerBrush()
        {
            Brush bg;
            switch (BehandlerID)
            {
                case 8:
                    {
                        bg = new SolidColorBrush(Colors.LightSalmon);
                        break;
                    }

                case 10:
                    {
                        bg = new SolidColorBrush(Colors.LightBlue);
                        break;
                    }
                case 9:
                    {
                        bg = new SolidColorBrush(Colors.LimeGreen);
                        break;
                    }
                default:
                    {
                        bg = new SolidColorBrush(Colors.White);
                        break;
                    }
            }

            BehandlerBackground = bg;

        }



        #endregion



    }
}
