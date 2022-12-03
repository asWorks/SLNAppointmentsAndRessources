using AppointmentsAndRessources.Events;
using AppointmentsAndRessources.Interfaces;
using AppointmentsAndRessourses.ViewModels;
using Caliburn.Micro;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AppointmentsAndRessources.ViewModels
{
    [Export(typeof(IWeekDisplayViewModel))]
    public class WeekDisplayViewModel : Screen, IWeekDisplayViewModel, IHandle<RequestPatientenInfoMessage>
    {

        IEventAggregator _eventAggregator;
        DbContext TherapiContext = null;
        IDateTimeService _DateTimeService;
        bool bTemp = false;

        #region "Properties"



        private bool _IsLoadingData;
        public bool IsLoadingData
        {
            get { return _IsLoadingData; }
            set
            {
                if (value != _IsLoadingData)
                {

                    _IsLoadingData = value;
                    NotifyOfPropertyChange(() => IsLoadingData);


                }
            }
        }
        private int _WeekNumber;
        public int WeekNumber
        {
            get { return _WeekNumber; }

            set
            {
                if (value != _WeekNumber)
                {
                    _WeekNumber = value;
                    NotifyOfPropertyChange(() => WeekNumber);

                    // IsLoadingData = true;

                    // LoadSelectedWeek(WeekNumber);
                }
            }
        }

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




        #endregion




        #region "Constructors"

        [ImportingConstructor]
        public WeekDisplayViewModel(IDateTimeService dateTimeService,IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
            _DateTimeService = dateTimeService;

            TherapiContext = new MySQL_Dal.GuesterModel();

            var repo = new Dal.Repositories.GenericRepository<MySQL_Dal.kollegen2>(TherapiContext);

            var behandler = repo.All();

            Behandler = new ObservableCollection<MySQL_Dal.kollegen2>(behandler);


            var patRepo = new Dal.Repositories.GenericRepository<MySQL_Dal.pat5>(TherapiContext);
            var pat = patRepo.All();
            Patienten = new ObservableCollection<MySQL_Dal.pat5>(pat.OrderBy(i => i.N_NAME));

            WeekNumber = 28;
            IncreaseWeek();
        }
        #endregion


        #region "Methods"




        //private async Task LoadWeek(int wNumb)
        //{
        //    await LoadSelectedWeekASync(wNumb);
        //}

        //private async Task LoadSelectedWeekASync(int wNumber)
        //{
        //    //await Task.Factory.StartNew((i) => LoadSelectedWeek((int)i), wNumber)

        //   await LoadSelectedWeek(wNumber);

        //  //  Wochentage = new ObservableCollection<WeekDayViewModel>(wNumber);
        //    //IsLoadingData = false;
        //}

        public async void IncreaseWeek()
        {

            try
            {
                //await Task.Run(()=> LoadSelectedWeek(WeekNumber));
                WeekNumber++;
                await LoadSelectedWeek(WeekNumber);
            }
            finally
            {
                IsLoadingData = false;
            }


        }

        public async void DecreaseWeek()
        {
            try
            {
                WeekNumber--;
                await LoadSelectedWeek(WeekNumber);
            }
            catch (Exception)
            {

                IsLoadingData = false;
            }

        }

        public async Task<int> LoadSelectedWeek(int wNumber)
        {

            IsLoadingData = true;
          
            int buf = 0;
            Wochentage = new ObservableCollection<WeekDayViewModel>();
           
            SortedList<int, DateTime> Woche = await _DateTimeService.GetWeekDatesFromWeekNumberAsync(wNumber);
           
            
            foreach (var item in Woche)
            {
                var wt = new WeekDayViewModel(_eventAggregator, item.Value);
                Wochentage.Add(wt);
                buf += wt.Termine.Count;

            }

            return buf;

         

        }
        #endregion


        #region "CommandMethods"
        public void CollectDropInfo(object sender, MouseEventArgs e)
        {
            Rectangle rect = new Rectangle();
            if (sender is WeekDisplayViewModel vModel && e.LeftButton == MouseButtonState.Pressed)
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


        public void TestBusy()
        {
            // IsLoadingData = !IsLoadingData;
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

        public void BtnSaveChanges()
        {
            _eventAggregator.PublishOnUIThread(new SaveAppointmentsMessage(false));
        }

        #endregion


        #region "HandleMessages"
        /// <summary>
        /// Termin sendet Message und fordert die Daten des ausgewählten Patienten an.
        /// Wenn nicht Null wird werden die Daten incl. der TerminId zurückgeschickt mit Status isValid.
        /// Sonst wird null zurückgeschickt mit Status isValid = false
        /// </summary>
        /// <param name="message">TerminId des anfordernden Termins</param>
        public void Handle(RequestPatientenInfoMessage message)
        {

            if (SelectedPatient != null)
            {

                _eventAggregator.PublishOnUIThread(new PatientenInfoChangedMessage(new Domain.DTOs.DragDropPatientenInfo(SelectedPatient), true, message.TerminId));



            }
            else
            {
                //SelectedPatient is null
                //Send Message with State isNotValid so that calling appointment can handle it.
                _eventAggregator.PublishOnUIThread(new PatientenInfoChangedMessage(null, false, message.TerminId));


            }

        }
        #endregion

    }
}
