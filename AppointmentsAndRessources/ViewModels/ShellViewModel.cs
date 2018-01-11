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
   



        public TermineEditViewModel termineEditViewModel { get; set; }
        private readonly IEventAggregator _events;
        //KundenViewModel kdViewModel;
        //TermineViewModel tViewModel;
        //TabsViewModel tabsViewModel;

        //TestViewModel testVM;
        private readonly IAerzteListeViewModel AerzteListeVModel;



        public ShellViewModel()
        {



        }

        [ImportingConstructor]
        public ShellViewModel(IAerzteListeViewModel aerzteListeVm, IEventAggregator events)
        {
            _events = events;
            AerzteListeVModel = aerzteListeVm;
            termineEditViewModel = new TermineEditViewModel();
            events.Subscribe(this);

        }



        public void Termine()
        {
            ActivateItem(termineEditViewModel);
        }


        public void Test()
        {
            ActivateItem(new TestViewModel());
        }

        public void AerzteListe()
        {
            ActivateItem(AerzteListeVModel);

        }

        public void Handle(EventMessage message)
        {
            throw new NotImplementedException();
        }
    }
}