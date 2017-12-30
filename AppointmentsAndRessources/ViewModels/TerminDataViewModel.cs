using AppointmentsAndRessourses.Models;
using AppointmentsAndRessourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using Domain.Models;
using Caliburn.Micro;

namespace AppointmentsAndRessources.ViewModels
{
    public class TerminDataViewModel : Screen
    {

        #region "Functions"


        public TerminData GetModel()
        {
            var model = new TerminData { PatientenName = this.PatientenName, Behandler = this.Behandler, Termin = this.Termin, ID = this.ID };
            return model;

        }

        public void LoadFromModel(TerminData model)
        {
            var vm = new TerminDataViewModel { PatientenName = this.PatientenName, Behandler = this.Behandler, Termin = this.Termin, ID = this.ID };
            //    return vm;
        }


        public void SetBehandlerBrush()
        {
            Brush bg;
            switch (Behandler)
            {
                case "Mariann":
                    {
                        bg = new SolidColorBrush(Colors.LightGreen);
                        break;
                    }

                case "Anja":
                    {
                        bg = new SolidColorBrush(Colors.LightSkyBlue);
                        break;
                    }
                case "Alex":
                    {
                        bg = new SolidColorBrush(Colors.LightYellow);
                        break;
                    }
                case "Maggie":
                    {
                        bg = new SolidColorBrush(Colors.PaleGreen);
                        break;
                    }
                case "Kyra":
                    {
                        bg = new SolidColorBrush(Colors.PaleTurquoise);
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
                        bg = new SolidColorBrush(Colors.White);
                        break;
                    }
            }

            TerminBackground = bg;

        }

        #endregion

        #region "Constructors"
        public TerminDataViewModel()
        {
            Patienten = new ObservableCollection<string> { "Freier Termin", "Arpad Stöver", "Helmut Kahl", "Knut Kummert", "Georg Witt", "Jennifer Walter", "Marc Marcieu" };
            SelectedPatient = Patienten[0];
        }


        public TerminDataViewModel(TerminData model)
        {
            PatientenName = model.PatientenName;
            Behandler = model.Behandler;
            Termin = model.Termin;
            ID = model.ID;
        }

        #endregion

        #region "Collections"

        private ObservableCollection<string> _Patienten;

        public static explicit operator TerminDataViewModel(ListViewItem v)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<string> Patienten
        {
            get { return _Patienten; }
            set
            {
                if (value != _Patienten)
                {
                    _Patienten = value;
                    NotifyOfPropertyChange(() => Patienten);
                    //  isDirty = true;
                }
            }
        }


        #endregion

        #region "Properties"

        private string _SelectedPatient;
        public string SelectedPatient
        {
            get { return _SelectedPatient; }
            set
            {
                if (value != _SelectedPatient)
                {
                    _SelectedPatient = value;
                    NotifyOfPropertyChange(() => SelectedPatient);
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

                    SetBehandlerBrush();
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
                    NotifyOfPropertyChange(() => Termin);
                    //  isDirty = true;
                }
            }
        }


        private string _ID;
        public string ID
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


        private bool _isSelected;
        public bool isSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    SetSelectedBrush(value);
                    _isSelected = value;
                    NotifyOfPropertyChange(() => isSelected);
                    //  isDirty = true;
                }
            }
        }


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
        #endregion



        #region "EventHandlers"


       public void ListView_Drop(object sender, DragEventArgs e)
        {

        }

        #endregion


    }



}
