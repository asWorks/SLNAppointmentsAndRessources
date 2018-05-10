using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsAndRessourses.Models;
using AppointmentsAndRessources.ViewModels;
using AppointmentsAndRessources.HelperClasses;
using Caliburn.Micro;
using AppointmentsAndRessources.Events;
using AppointmentsAndRessources.Interfaces;
using System.ComponentModel.Composition;
using Services;

namespace AppointmentsAndRessourses.ViewModels
{
    public class WeekDayViewModel : Screen, IWeekDayViewModel, IHandle<RadioButtonNameMessage>,IHandle<BehandlerFilterMessage>,IHandle<TermineFilterMessage>,IHandle<SaveAppointmentsMessage>

    {

        public event Action<string> RadioButtonClick;

        AppointmentDataService _ApoService;



        IEventAggregator _eventaggegator;


        private DateTime _Datum;
        public DateTime Datum
        {
            get { return _Datum; }
            set
            {
                if (value != _Datum)
                {
                    _Datum = value;
                    NotifyOfPropertyChange(() => Datum);
                    //  isDirty = true;
                }
            }
        }

        //public RelayCommand ShowAllTermine { get; set; }
        //public RelayCommand ShowTermineMariann { get; set; }
        //public RelayCommand ShowTermineMaggie { get; set; }
        //public RelayCommand ShowTermineAnja { get; set; }


        public List<TerminDataViewModel> AlleTermine { get; set; }

        public List<Domain.Models.TerminData> AlleTermineModel { get; set; }


        private ObservableCollection<TerminDataViewModel> _Termine;
        public ObservableCollection<TerminDataViewModel> Termine
        {


            get { return _Termine; }
            set
            {
                if (value != _Termine)
                {
                    _Termine = value;
                    NotifyOfPropertyChange(() => Termine);
                    //  isDirty = true;
                }
            }
        }





        public WeekDayViewModel(IEventAggregator aggregator, DateTime datum )
        {
            _eventaggegator = aggregator;
            aggregator.Subscribe(this);

            Datum = datum;
            _ApoService = new AppointmentDataService();


            AddTermine();

         

        }

        private void AddTermine()
        {
           

            //var repo = new Dal.Repositories.GenericRepository<MySQL_Dal.kollegen2>(new MySQL_Dal.GuesterModel());


            //var behandler = repo.All();

            //var Beh = new List<MySQL_Dal.kollegen2>(behandler);

            Termine = new ObservableCollection<TerminDataViewModel>();
            AlleTermine = new List<TerminDataViewModel>();
            AlleTermineModel = _ApoService.GetTerminListe(Datum);

            foreach (var item in AlleTermineModel)
            {
                var td = new TerminDataViewModel(item, _eventaggegator);
                AlleTermine.Add(td);
                

            }




            //int counter = 0;
            //var t = new DateTime(2017, 11, 13, 8, 0, 0);

            //for (int i = 1; i < 20; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        ++counter;


            //        var td = new TerminDataViewModel(_eventaggegator)
            //        {
            //            PatientenName = "Freier Termin",
            //            Behandler = Beh[j].VORNAME,
            //            BehandlerID = Beh[j].ID,
            //            ID = TempHelperFunctions.GetCounter(),
            //            Termin = t
            //        };



            //        //Termine.Add(td);
            //        AlleTermine.Add(td);
            //        t = t.AddDays(1);
            //    }


            //    t = t.AddMinutes(30);
            //}

            Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine);

        }

        public void addTerminData()
        {
            var x = new TerminDataViewModel { PatientenName = "Marc Marcieu", Behandler = "Anja", Termin = new DateTime(2017, 11, 6, 11, 25, 0), ID = 125 };
            Termine.Add(x);
        }

        public void Test123()
        {

            int y = 42;
        }

        public void BtnSave()
        {

          int res=  _ApoService.SaveAppointments();
            int x = res;
        }


        public void Handle(RadioButtonNameMessage message)
        {
            RadioButtonClick?.Invoke(message.ButtonName);

        }

        public void Handle(BehandlerFilterMessage message)
        {
            int res = message.Message;

            Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.BehandlerID ==res));

            

        }

        public void Handle(TermineFilterMessage message)
        {
            switch (message.TerminFilter)
            {
                case TermineFilterMessage.EnumFilterMessage.Alle:
                    {
                        Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine);
                        break;
                    }
                case TermineFilterMessage.EnumFilterMessage.Vergebene:
                    {
                        Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n=>n.isSelected==true));
                        break;
                    }
                case TermineFilterMessage.EnumFilterMessage.Freie:
                    {
                        Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.isSelected == false));
                        break;
                    }
                default:
                    break;
            }
        }

        public void Handle(SaveAppointmentsMessage message)
        {
            if (message.DoAskBeforeSave != true)
            {
                _ApoService.SaveAppointments();
            }
        }
    }
}
