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
using Microsoft.Extensions.Logging;

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

        public IEnumerable<Domain.Models.TerminData> AlleTermineModel { get; set; }


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

        private async void AddTermine()
        {
           

            Termine = new ObservableCollection<TerminDataViewModel>();
            AlleTermine = new List<TerminDataViewModel>();


            var res = await _ApoService.GetTerminListe(Datum);
            AlleTermineModel = res;

            foreach (var item in AlleTermineModel)
            {
                var td = new TerminDataViewModel(item, _eventaggegator);
                AlleTermine.Add(td);
                

            }

            Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine);

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

            //Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.BehandlerID ==res));

            

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
                        Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n=>n.IsSelected==true));
                        break;
                    }
                case TermineFilterMessage.EnumFilterMessage.Freie:
                    {
                        Termine = new ObservableCollection<TerminDataViewModel>(AlleTermine.Where(n => n.IsAppointmentAvailable == true));
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
