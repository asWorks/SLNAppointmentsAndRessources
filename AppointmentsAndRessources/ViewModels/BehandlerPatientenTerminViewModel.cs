using AppointmentsAndRessources.Events;
using Caliburn.Micro;
using Domain.Models;
using System;
using System.Windows.Media;

namespace AppointmentsAndRessources.ViewModels
{
    public class BehandlerPatientenTerminViewModel : Screen, IHandle<PatientenInfoChangedMessage>
    {

        #region "Local Fields"
        private IEventAggregator _eventAggregator;


        #endregion

        #region "Constructors"

        private BehandlerPatientenTermin bpt;

        public BehandlerPatientenTerminViewModel(BehandlerPatientenTermin model, IEventAggregator aggregator)
        {


            _eventAggregator = aggregator;
            aggregator.Subscribe(this);

            bpt = model;
            ID = model.ID;
            Termin = model.Termin;
            BehandlerID = model.BehandlerID;
            PatientenID = model.PatientenID;
            PatientenVorname = model.PatientenVorname;
            PatientenNachname = model.PatientenNachname;
            BehandlerVorname = model.BehandlerVorname;
            BehandlerNachname = model.BehandlerNachname;
            MandantID = model.MandantID;
            RezeptID = model.RezeptID;
            this.istVergeben = model.istVergeben;
            this.istAusgefuehrt = model.istAusgefuehrt;
            SetBehandlerPatientenName();

            ImageUriLink = new Uri("pack://application:,,,/AppointmentsAndRessources; component/Assets/Pictures/Link_02_24.png",UriKind.Absolute);
            //"pack://application:,,,/ApplicationNamespace;component/Images/App/image.png";
            // AppointmentsAndRessources; component / Assets / Pictures / Link_02_24.png"
        }

        private void SetBehandlerPatientenName()
        {
            BehandlerName = BehandlerVorname + " " + BehandlerNachname;
            PatientenName = PatientenVorname + " " + PatientenNachname;
        }


        #endregion

        #region "Properties"


        public string ImagePathTest
        {
            get { return "/AppointmentsAndRessources;component/Assets/Pictures/Link_02_48.png"; }
        }


        private string _ImagePathInfo;
        public string ImagePathInfo
        {
            get { return _ImagePathInfo; }
            set
            {
                if (value != _ImagePathInfo)
                {
                    _ImagePathInfo = value;
                    NotifyOfPropertyChange(() => ImagePathInfo);
                    //  isDirty = true;
                }
            }
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (value != _ID)
                {
                    _ID = value;
                    NotifyOfPropertyChange(() => ID);
                    //  isDirty = true;
                }
            }
        }

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


        private string _PatientenVorname;
        public string PatientenVorname
        {
            get { return _PatientenVorname; }
            set
            {
                if (value != _PatientenVorname)
                {
                    _PatientenVorname = value;
                    bpt.PatientenVorname = value;

                    NotifyOfPropertyChange(() => PatientenVorname);
                    //  isDirty = true;
                }
            }
        }


        private string _PatientenNachname;
        public string PatientenNachname
        {
            get { return _PatientenNachname; }
            set
            {
                if (value != _PatientenNachname)
                {
                    _PatientenNachname = value;
                    bpt.PatientenNachname = value;
                    NotifyOfPropertyChange(() => PatientenNachname);
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




        private string _BehandlerVorname;
        public string BehandlerVorname
        {
            get { return _BehandlerVorname; }
            set
            {
                if (value != _BehandlerVorname)
                {
                    _BehandlerVorname = value;
                    bpt.BehandlerVorname = value;
                    SetBehandlerPatientenName();
                    NotifyOfPropertyChange(() => BehandlerVorname);
                    //  isDirty = true;
                }
            }
        }



        private string _BehandlerNachname;
        public string BehandlerNachname
        {
            get { return _BehandlerNachname; }
            set
            {
                if (value != _BehandlerNachname)
                {
                    _BehandlerNachname = value;
                    bpt.BehandlerNachname = value;
                    SetBehandlerPatientenName();
                    NotifyOfPropertyChange(() => BehandlerNachname);
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
                    isSelected = value;
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

        private bool _isSelected;
        public bool isSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    bpt.istVergeben = value;
                    SetSelectedBrush(value);
                    NotifyOfPropertyChange(() => isSelected);
                    //  isDirty = true;
                }
            }
        }




        private Uri _ImageUriLink;
        public Uri ImageUriLink
        {
            get { return _ImageUriLink; }
            set
            {
                if (value != _ImageUriLink)
                {
                    _ImageUriLink = value;
                    NotifyOfPropertyChange(() => ImageUriLink);
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

        public void CheckTermin()
        {

            //isSelected = !isSelected;
            if (!isSelected)
            {

                _eventAggregator.PublishOnUIThread(new RequestPatientenInfoMessage(this.ID));
               
            }
            else
            {

               // isSelected = false;
            }



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

        #region "Events"

        public void Handle(PatientenInfoChangedMessage message)
        {
            if (message != null)
            {
                if (message.TerminId == this.ID && message.isInValidState == true)
                {
                    PatientenID = message.patientenInfo.PatientenId;

                    PatientenVorname = message.patientenInfo.PatientenVorname;
                    PatientenNachname = message.patientenInfo.PatientenNachname;
                    ImagePathInfo = "/AppointmentsAndRessources;component/Assets/Pictures/Bulb_green_48.png";


                    isSelected = true;

                }


            }
        }

        #endregion

    }
}
