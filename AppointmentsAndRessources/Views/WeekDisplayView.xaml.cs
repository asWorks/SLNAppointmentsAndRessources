using AppointmentsAndRessources.ViewModels;
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
    /// Interaction logic for WeekDisplayViewModel.xaml
    /// </summary>
    public partial class WeekDisplayView : UserControl
    {

        WeekDisplayViewModel vm;

        public WeekDisplayView()
        {
            InitializeComponent();
            this.DataContextChanged += WeekDisplayView_DataContextChanged;
            this.UpDownWeekNumber.Value = 29;
        }

        private void WeekDisplayView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                if (this.DataContext is WeekDisplayViewModel)
                {
                    vm = (WeekDisplayViewModel)this.DataContext;
                }


            }
        }

        private void TestBusy_Click(object sender, RoutedEventArgs e)
        {
            this.BusyIndicator.IsBusy = !this.BusyIndicator.IsBusy;
        }

        private void UpDownWeekNumber_ValueChanging(object sender, Syncfusion.Windows.Shared.ValueChangingEventArgs e)
        {

        }

        private async void UpDownWeekNumber_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (vm != null)
            {
                var ud = (Syncfusion.Windows.Shared.UpDown)d;
                await vm.LoadSelectedWeek((int)ud.Value);
            }

        }

        private void UpDownWeekNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.BusyIndicator.IsBusy = true;
        }
    }
}
