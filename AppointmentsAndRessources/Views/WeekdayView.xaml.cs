using AppointmentsAndRessourses.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppointmentsAndRessources.Views
{
    /// <summary>
    /// Interaction logic for Weekday.xaml
    /// </summary>
    public partial class WeekdayView : UserControl
    {
        public WeekdayView()
        {
            InitializeComponent();
            SetRessource();
           


            this.DataContextChanged += Weekday_DataContextChanged;

        }

        private void Weekday_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                WeekDayViewModel vm = (WeekDayViewModel)this.DataContext;
                vm.RadioButtonClick += Vm_RadioButtonClick;
            }
        }

            private void Vm_RadioButtonClick(string obj)
        {
            
            if (obj == "RBFull")
            {
                var templ = (DataTemplate)this.MainGrid.FindResource("TermineDataUCFullTemplate");
                WeekdayListBox.ItemTemplate = templ;
            }
            else if (obj == "RBBasic")
            {
                var templ = (DataTemplate)this.MainGrid.FindResource("TermineDataUCTemplate");
                WeekdayListBox.ItemTemplate = templ;
            }
            else if (obj == "RBAll")
            {
                var templ = (DataTemplate)this.MainGrid.FindResource("TermineDataUCAllTemplate");
                WeekdayListBox.ItemTemplate = templ;
            }


            else
            {
                var templ = (DataTemplate)this.MainGrid.FindResource("TermineDataUCAllTemplate");
                WeekdayListBox.ItemTemplate = templ;
            }
        }

        void SetRessource()
        {

            var templ = (DataTemplate)this.MainGrid.FindResource("TermineDataUCAllTemplate");
            WeekdayListBox.ItemTemplate = templ;

        }

      
    }
}
