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
               
                isSelected = false;
            }



        }

        public TerminData GetModel()
        {
            var bpt = new List<BehandlerPatientenTermin>();
            foreach (var item in this.BehandlerPatientenTermine)
            {
                bpt.Add(item.GetModel());
            }
            var model = new TerminData(this.ID, this.Termin, bpt);
           
            return model;

        }

        public void LoadFromModel(TerminData model)
        {
            Termin = model.Termin;
            ID = model.ID;
            BehandlerPatientenTerminViewModel bptvm;
            var bpt = new ObservableCollection<BehandlerPatientenTerminViewModel>();
            foreach (var item in model.BehandlerPatientenTermine)
            {
                bptvm = new BehandlerPatientenTerminViewModel(item);
                bpt.Add(bptvm);
            }

            this.BehandlerPatientenTermine = bpt;
            //var vm = new TerminDataViewModel { Termin = this.Termin, ID = this.ID, BehandlerPatientenTermine = bpt };
            //    return vm;
        }


     

      

        #endregion

        #region "Constructors"
        public TerminDataViewModel()
        {
          
        }

        public TerminDataViewModel(IEventAggregator aggregator)
        {
            _eventAggregator = aggregator;
            aggregator.Subscribe(this);
        }


        public TerminDataViewModel(TerminData model,IEventAggregator aggregator):this(aggregator)
        {
            TerminBackground = new SolidColorBrush(Colors.White);
            Appointment = model;
            LoadFromModel(model);
            
            
           
        }

        #endregion

        #region "Collections"


        private ObservableCollection<BehandlerPatientenTerminViewModel> _BehandlerPatientenTermine;
        public ObservableCollection<BehandlerPatientenTerminViewModel> BehandlerPatientenTermine
        {
            get { return _BehandlerPatientenTermine; }
            set
            {
                if (value != _BehandlerPatientenTermine)
                {
                    _BehandlerPatientenTermine = value;
                    NotifyOfPropertyChange(() => BehandlerPatientenTermine);
                    //  isDirty = true;
                }
            }
        }


        #endregion

        #region "Properties"





        private Domain.Models.TerminData _Appointment;
        public Domain.Models.TerminData Appointment
        {
            get { return _Appointment; }
            set
            {
                if (value != _Appointment)
                {
                    _Appointment = value;
                    NotifyOfPropertyChange(() => Appointment);
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
                    Appointment.Termin = value;
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
                    Appointment.ID = value;
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
                    //SetSelectedBrush(value);
                    _isSelected = value;
                    //Appointment.istVergeben = value;
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

            //PatientenID = dragged.PatientenId;
            //PatientenName = dragged.PatientenFullName;
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
                    //PatientenID = message.patientenInfo.PatientenId;
                    //PatientenName = message.patientenInfo.PatientenFullName;
                 
                 
                    isSelected = true;

                }


            }


        }

    }

    #endregion


}



