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
using AppointmentsAndRessources.Interfaces;
using AppointmentsAndRessources.Events;

namespace AppointmentsAndRessources.ViewModels
{
    public class TerminDataViewModel : Screen, ITerminDataViewModel, IHandle<PatientenInfoChangedMessage>
    {

        IEventAggregator _eventAggregator;
        //bool sendRequest = false;


        #region "Functions"

        public void CheckTermin()
        {

            //isSelected = !isSelected;
            if (!isSelected)
            {

                _eventAggregator.PublishOnUIThread(new RequestPatientenInfoMessage(this.ID));
            }
            else
            {
                this.PatientenID = 0;
                this.PatientenName = "Freier Termin";
                isSelected = false;
            }



        }

        public TerminData GetModel()
        {
            var model = new TerminData { PatientenName = this.PatientenName, PatientenID = this.PatientenID, BehandlerID = this.BehandlerID, Behandler = this.Behandler, Termin = this.Termin, ID = this.ID };
            return model;

        }

        public void LoadFromModel(TerminData model)
        {
            var vm = new TerminDataViewModel { PatientenName = this.PatientenName, PatientenID = this.PatientenID, BehandlerID = this.BehandlerID, Behandler = this.Behandler, Termin = this.Termin, ID = this.ID };
            //    return vm;
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

        #endregion

        #region "Constructors"
        public TerminDataViewModel()
        {
            //Patienten = new ObservableCollection<string> { "Freier Termin", "Arpad Stöver", "Helmut Kahl", "Knut Kummert", "Georg Witt", "Jennifer Walter", "Marc Marcieu" };
            //SelectedPatient = Patienten[0];
        }

        public TerminDataViewModel(IEventAggregator aggregator)
        {
            _eventAggregator = aggregator;
            aggregator.Subscribe(this);
        }


        public TerminDataViewModel(TerminData model)
        {
            PatientenName = model.PatientenName;
            Behandler = model.Behandler;
            PatientenID = model.PatientenID;
            BehandlerID = model.BehandlerID;
            Termin = model.Termin;
            ID = model.ID;
            TerminBackground = new SolidColorBrush(Colors.LightBlue);
        }

        #endregion

        #region "Collections"

        //private ObservableCollection<string> _Patienten;

        //public static explicit operator TerminDataViewModel(ListViewItem v)
        //{
        //    throw new NotImplementedException();
        //}


        #endregion

        #region "Properties"


        private int _PatientenID;
        public int PatientenID
        {
            get { return _PatientenID; }
            set
            {
                if (value != _PatientenID)
                {
                    _PatientenID = value;
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
                    NotifyOfPropertyChange(() => PatientenName);
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
                    NotifyOfPropertyChange(() => BehandlerID);
                    SetBehandlerBrush();
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



        public void GetDropInfo(object sender, DragEventArgs e)
        {

            var dataObj = e.Data as DataObject;
            var dragged = dataObj.GetData(typeof(Domain.DTOs.DragDropPatientenInfo)) as Domain.DTOs.DragDropPatientenInfo;

            //var v = (TerminDataViewModel)this.DataContext;

            PatientenID = dragged.PatientenId;
            PatientenName = dragged.PatientenFullName;
            isSelected = true;
        }


        public void ListView_Drop(object sender, DragEventArgs e)
        {

        }


        void ManageTerminSelection(bool value)
        {

        }

        public void Handle(PatientenInfoChangedMessage message)
        {

            if (message != null)
            {
                if (message.TerminId == this.ID && message.isInValidState == true)
                {
                    PatientenID = message.patientenInfo.PatientenId;
                    PatientenName = message.patientenInfo.PatientenFullName;
                    isSelected = true;

                }


            }


        }

    }

    #endregion


}



