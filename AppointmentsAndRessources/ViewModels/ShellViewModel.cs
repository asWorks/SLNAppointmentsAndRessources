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
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<object>, IShellViewModel, IHandle<Events.EventMessage>
    {
   


        private readonly IEventAggregator _events;
        private readonly IAerzteListeViewModel AerzteListeVModel;
        private readonly IWeekDisplayViewModel weekDisplayViewModel;
        private readonly ITestPeopleViewModel testPeopleViewModel;

        //public IWeekDisplayViewModel weekDisplayViewModel { get; set; }

       

        



        #region Constructors
        public ShellViewModel()
        {



        }

        [ImportingConstructor]
        public ShellViewModel(IAerzteListeViewModel aerzteListeVm,
            IWeekDisplayViewModel weekDisplayVM,
            ITestPeopleViewModel testPeopleVM,
            IEventAggregator events)
        {
            _events = events;
            AerzteListeVModel = aerzteListeVm;
            //weekDisplayViewModel = new WeekDisplayViewModel();
            weekDisplayViewModel = weekDisplayVM;
            testPeopleViewModel = testPeopleVM;

            events.Subscribe(this);

        } 
        #endregion



        public void Termine()
        {
            ActivateItem(weekDisplayViewModel);
        }


        public void Test()
        {
            ActivateItem(new TestViewModel());
        }

        public void AerzteListe()
        {
            ActivateItem(AerzteListeVModel);

        }

        public void TestPeople()
        {
            ActivateItem(testPeopleViewModel);
        }

        public void Handle(EventMessage message)
        {
            throw new NotImplementedException();
        }
    }
}