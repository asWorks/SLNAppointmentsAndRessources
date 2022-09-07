using AppointmentsAndRessources.Events;
using Caliburn.Micro;
using Domain.Models;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Media;
using AppointmentsAndRessources.Extensions;
using System.Windows;

namespace AppointmentsAndRessources.ViewModels
{
    public class BehandlerPatientenTerminViewModel : Screen, IHandle<PatientenInfoChangedMessage>
    {

        #region "Local Fields"
        private IEventAggregator _eventAggregator;
        private BehandlerPatientenTermin bpt;


        #endregion

        #region "Constructors"


        public BehandlerPatientenTerminViewModel(BehandlerPatientenTermin model, TerminDataViewModel terminDataVM, IEventAggregator aggregator)
        {


            _eventAggregator = aggregator;
            aggregator.Subscribe(this);

            TerminDataVM = terminDataVM;
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
            this.IstVergeben = model.IstVergeben;
            this.IstAusgefuehrt = model.istAusgefuehrt;
            SetBehandlerPatientenName();

            ImageUriLink = new Uri("pack://application:,,,/AppointmentsAndRessources; component/Assets/Pictures/Link_02_24.png", UriKind.Absolute);
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



        private TerminDataViewModel _TerminDataVM;
        public TerminDataViewModel TerminDataVM
        {
            get { return _TerminDataVM; }
            set
            {
                if (value != _TerminDataVM)
                {
                    _TerminDataVM = value;
                    NotifyOfPropertyChange(() => TerminDataVM);
                    //  isDirty = true;
                }
            }
        }

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
        public bool IstVergeben
        {
            get { return _istVergeben; }
            set
            {
                //if (value != _istVergeben)
                if (true)
                {
                    _istVergeben = value;
                    bpt.IstVergeben = value;
                    IsSelected = value;
                    NotifyOfPropertyChange(() => IstVergeben);
                    SetParentTermin(value);

                    //  isDirty = true;
                }
            }
        }



        private bool _istAusgefuehrt;
        public bool IstAusgefuehrt
        {
            get { return _istAusgefuehrt; }
            set
            {
                if (value != _istAusgefuehrt)
                {
                    _istAusgefuehrt = value;
                    bpt.istAusgefuehrt = value;
                    NotifyOfPropertyChange(() => IstAusgefuehrt);
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
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    bpt.IstVergeben = value;
                    SetSelectedBrush(value);
                    NotifyOfPropertyChange(() => IsSelected);
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
            if (!IsSelected)
            {

                _eventAggregator.PublishOnUIThread(new RequestPatientenInfoMessage(this.ID));

            }
            else
            {
                PatientenID = 0;

                PatientenVorname = "Nicht";
                PatientenNachname = "vergeben";
                ImagePathInfo = "/AppointmentsAndRessources;component/Assets/Pictures/Link_02_24.png";
                IsSelected = false;
            }



        }

        private void SetParentTermin(bool value)
        {

            int claimed = TerminDataVM.BehandlerPatientenTermine == null ? -1 : TerminDataVM.BehandlerPatientenTermine.Count(x => x.IstVergeben == true);

            switch (claimed)
            {
                case 0:
                    TerminDataVM.IsSelected = false;
                    TerminDataVM.IsAppointmentAvailable = true;
                    break;

                case int n when (n >= 0 && n <= 2):
                    TerminDataVM.IsSelected = true;
                    TerminDataVM.IsAppointmentAvailable = true;
                    break;

                case 3:
                    TerminDataVM.IsSelected = true;
                    TerminDataVM.IsAppointmentAvailable = false;
                    break;

                case -1:
                    break;
                default:
                    break;
            }

            //if (value)
            //{
            //    TerminDataVM.isSelected = value;
            //}
            //else
            //{

            //    var buffer = TerminDataVM.BehandlerPatientenTermine.Where(x => x.istVergeben == true);
            //    if (buffer.Any())
            //    {
            //        TerminDataVM.isSelected = true;
            //    }
            //    else
            //    {
            //        TerminDataVM.isSelected = value;
            //    }


            //}
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
        /// <summary>
        /// Sets the background color of the selected appointment.
        /// Boolean flag is converted into color values ​​in the method.
        /// Currently hard-coded - maybe later configurable in Settings.
        /// </summary>
        /// <param name="flag"></param>
        public void SetSelectedBrush(bool flag)
        {
            //RegistryKey key=Registry.CurrentUser.CreateSubKey(@"SOFTWARE\asWorks.de\Terminverwaltung\Colors");
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\asWorks.de\Terminverwaltung\Colors");



            try
            {

                var r = byte.Parse(key.GetValue("SetSelectedTerminBrushRed").ToString());
                var g = byte.Parse(key.GetValue("SetSelectedTerminBrushGreen").ToString());
                var b = byte.Parse(key.GetValue("SetSelectedTerminBrushBlue").ToString());
                var color = Color.FromRgb(r, g, b);
                TerminBackground = flag == true ? new SolidColorBrush(color) : new SolidColorBrush(Colors.White);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                // MessageBox.Show(s1);
            }

            //string s1 = 0xff0000.ToString();
            //int i1 = int.Parse(s1);

            //string s = key.GetValue("SetSelectedTerminBrush").ToString();
            //s = s.Replace("#", "0x");
            //s = s.ToLower();
            //int i = int.Parse(s);


            //string s1 = 0xff0000.ToString();









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
                    ImagePathInfo = "/AppointmentsAndRessources;component/Assets/Pictures/Bulb_green_24.png";


                    IsSelected = true;

                }


            }
        }

        #endregion

    }
}
