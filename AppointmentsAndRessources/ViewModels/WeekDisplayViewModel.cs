using AppointmentsAndRessources.Events;
using AppointmentsAndRessources.Interfaces;
using AppointmentsAndRessourses.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace AppointmentsAndRessources.ViewModels
{
    [Export(typeof(IWeekDisplayViewModel))]
    public class WeekDisplayViewModel : Screen, IWeekDisplayViewModel,IHandle<RequestPatientenInfoMessage>
    {

        IEventAggregator _eventAggregator;
        DbContext TherapiContext = null;


        private ObservableCollection<WeekDayViewModel> _Wochentage;
        public ObservableCollection<WeekDayViewModel> Wochentage
        {
            get { return _Wochentage; }
            set
            {
                if (value != _Wochentage)
                {
                    _Wochentage = value;
                    NotifyOfPropertyChange(() => Wochentage);
                    //  isDirty = true;
                }
            }
        }


        private ObservableCollection<MySQL_Dal.kollegen2> _Behandler;
        public ObservableCollection<MySQL_Dal.kollegen2> Behandler
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



        private MySQL_Dal.kollegen2 _SelectedBehandler;
        public MySQL_Dal.kollegen2 SelectedBehandler
        {
            get { return _SelectedBehandler; }
            set
            {
                if (value != _SelectedBehandler)
                {
                    _SelectedBehandler = value;
                    _eventAggregator.PublishOnUIThread(new BehandlerFilterMessage(_SelectedBehandler.ID));
                    NotifyOfPropertyChange(() => SelectedBehandler);
                    //  isDirty = true;
                }
            }
        }





        private ObservableCollection<MySQL_Dal.pat5> _Patienten;
        public ObservableCollection<MySQL_Dal.pat5> Patienten
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


        private MySQL_Dal.pat5 _SelectedPatient;
        public MySQL_Dal.pat5 SelectedPatient
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







        [ImportingConstructor]
        public WeekDisplayViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
            TherapiContext = new MySQL_Dal.GuesterModel();

            Wochentage = new ObservableCollection<WeekDayViewModel>();
            for (int i = 0; i < 20; i++)
            {
                var wt = new WeekDayViewModel(_eventAggregator);
                wt.Datum = DateTime.Now.AddDays(i);
                Wochentage.Add(wt);
            }

            var repo = new Dal.Repositories.GenericRepository<MySQL_Dal.kollegen2>(TherapiContext);

            var behandler = repo.All();

            Behandler = new ObservableCollection<MySQL_Dal.kollegen2>(behandler);


            var patRepo = new Dal.Repositories.GenericRepository<MySQL_Dal.pat5>(TherapiContext);
            var pat = patRepo.All();
            Patienten = new ObservableCollection<MySQL_Dal.pat5>(pat.OrderBy(i => i.N_NAME));

        }



        public void CollectDropInfo(object sender, MouseEventArgs e)
        {
            Rectangle rect = new Rectangle();
            WeekDisplayViewModel vModel = sender as WeekDisplayViewModel;
            if (vModel != null && e.LeftButton == MouseButtonState.Pressed)
            {


               if (vModel.SelectedPatient != null)
                {
                    var ddInfo = new Domain.DTOs.DragDropPatientenInfo(vModel.SelectedPatient);
                    //ddInfo.PatientenId = vModel.SelectedPatient.id;
                    //ddInfo.PatientenFullName = string.Format("{0} {1}", vModel.SelectedPatient.V_NAME, vModel.SelectedPatient.N_NAME);
                    var dragData = new DataObject(typeof(Domain.DTOs.DragDropPatientenInfo), ddInfo);
                    DragDrop.DoDragDrop(rect, dragData, DragDropEffects.Copy);
                }




            }
        }


        public void RadioButtonFull()
        {
            _eventAggregator.PublishOnUIThread(new Events.RadioButtonNameMessage("RBFull"));
        }

        public void RadioButtonBasic()
        {
            _eventAggregator.PublishOnUIThread(new Events.RadioButtonNameMessage("RBBasic"));
        }

        public void RadioButtonAll()
        {
            _eventAggregator.PublishOnUIThread(new Events.RadioButtonNameMessage("RBAll"));
        }

        public void RadioButtonTermineAlle()
        {
            _eventAggregator.PublishOnUIThread(new Events.TermineFilterMessage(TermineFilterMessage.EnumFilterMessage.Alle));
        }

        public void RadioButtonTermineVergeben()
        {
            _eventAggregator.PublishOnUIThread(new Events.TermineFilterMessage(TermineFilterMessage.EnumFilterMessage.Vergebene));
        }

        public void RadioButtonTermineFrei()
        {
            _eventAggregator.PublishOnUIThread(new Events.TermineFilterMessage(TermineFilterMessage.EnumFilterMessage.Freie));
        }

        /// <summary>
        /// Termin sendet Message und fordert die Daten des ausgewählten Patienten an.
        /// Wenn nicht Null wird werden die Daten incl. der TerminId zurückgeschickt mit Status isValid.
        /// Sonst wird null zurückgeschickt mit Status isValid = false
        /// </summary>
        /// <param name="message">TerminId des anfordernden Termins</param>
        public void Handle(RequestPatientenInfoMessage message)
        {

           if(SelectedPatient!=null)
            {
               
                    _eventAggregator.PublishOnUIThread(new PatientenInfoChangedMessage(new Domain.DTOs.DragDropPatientenInfo(SelectedPatient),true,message.TerminId));
               

               
            }
            else
            {
                     //SelectedPatient is null
                     //Send Message with State isNotValid so that calling appointment can handle it.
                    _eventAggregator.PublishOnUIThread(new PatientenInfoChangedMessage(null, false,message.TerminId));
              
                
            }

        }
    }
}
