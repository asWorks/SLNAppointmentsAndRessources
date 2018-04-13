using AppointmentsAndRessources.Events;
using AppointmentsAndRessources.Interfaces;
using AppointmentsAndRessourses.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{
    [Export(typeof(ITermineEditViewModel))]
    public class TermineEditViewModel:Screen,ITermineEditViewModel
    {

        IEventAggregator _eventAggregator;

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


        [ImportingConstructor]
        public TermineEditViewModel(IEventAggregator eventAggregator)
        {

            _eventAggregator = eventAggregator;

            Wochentage = new ObservableCollection<WeekDayViewModel>();
            for (int i = 0; i < 20; i++)
            {
                var wt = new WeekDayViewModel(_eventAggregator);
                wt.Datum = DateTime.Now.AddDays(i);
                Wochentage.Add(wt);
            }

            var repo = new Dal.Repositories.GenericRepository<MySQL_Dal.kollegen2>(new MySQL_Dal.GuesterModel());
                    
            var behandler = repo.All();

            Behandler = new ObservableCollection<MySQL_Dal.kollegen2>(behandler);
        }


        public void RadioButtonFull()
        {
            _eventAggregator.PublishOnUIThread(new Events.RadioButtonNameMessage("RBFull"));
        }

        public void RadioButtonBasic()
        {
            _eventAggregator.PublishOnUIThread(new Events.RadioButtonNameMessage("RBBasic"));
        }

    }
}
