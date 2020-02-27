using AppointmentsAndRessources.ViewModels;
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
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
        int i = 43;
        WeekDisplayViewModel vm;

        public WeekDisplayView()
        {
            InitializeComponent();
            this.DataContextChanged += WeekDisplayView_DataContextChanged;
            //this.UpDownWeekNumber.Value = 29;
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
            // this.BusyIndicator.IsBusy = !this.BusyIndicator.IsBusy;

            //BusyIndicator.IsBusy = true;
            //TestBusy.IsEnabled = false;
            //asBusyIndicator.Visibility = Visibility.Visible;

            //// await Task.Run(() => Task.Delay(5000));

            //if (vm != null)
            //{
            //    // var ud = (Syncfusion.Windows.Shared.UpDown)d;
            //    await vm.LoadSelectedWeek((int)i++);
            //}

            //BusyIndicator.IsBusy = false;
            //TestBusy.IsEnabled = true;
            //asBusyIndicator.Visibility = Visibility.Hidden;

        }


        private async void UpDownWeekNumber_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //int result = 0;
            //bool res = false;
            //BusyIndicator.IsBusy = res;
            //TestBusy.IsEnabled = !res;
            //asBusyIndicator.Visibility = res == true ? Visibility.Visible : Visibility.Hidden;

            //try
            //{
            //    if (vm != null)
            //    {
            //        var ud = (Syncfusion.Windows.Shared.UpDown)d;
            //        result = await vm.LoadSelectedWeek((int)ud.Value);
            //        // MessageBox.Show(result.ToString());
            //        res = true;
            //        BusyIndicator.IsBusy = !res;
            //        TestBusy.IsEnabled = res;
            //        asBusyIndicator.Visibility = res == true ? Visibility.Hidden : Visibility.Visible;



            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{

            //}




        }

        private void UpDownWeekNumber_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //this.BusyIndicator.IsBusy = true;
        }

        private async void TestBusy1_Click(object sender, RoutedEventArgs e)
        {

            vm.IsLoadingData = true;
            //try
            //{

            //    bool res = false;
            //    BusyIndicator.IsBusy = !res;
            //    TestBusy.IsEnabled = res;
            //    asBusyIndicator.Visibility = res == true ? Visibility.Visible : Visibility.Hidden;

            //    //res = await Task.Run<bool>(() => 
            //    //{

            //    //    return true;
            //    //});


            //    await Task.Run(() => Task.Delay(5000));

            //    res = true;
            //    BusyIndicator.IsBusy = !res;
            //    TestBusy.IsEnabled = res;
            //    asBusyIndicator.Visibility = res == true ? Visibility.Hidden : Visibility.Visible;


            //}
            //catch (Exception)
            //{


            //}




            //finally
            //{


            //}
        }

        private async void TestAsyncCall1_Click(object sender, RoutedEventArgs e)
        {
            var s = new Services.AppointmentDataService();

            var x = await s.GetTerminListe(new DateTime(2018, 11, 18));

            MessageBox.Show(x.Count.ToString());

        }

        private void ColorPicker1_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            string s;
            ColorPickerPalette colorPicker = d as ColorPickerPalette;

            TextBlock1.Text = Syncfusion.Windows.Shared.ColorEdit.SuchColor(colorPicker.Color)[0];
            TextBlock2.Text = colorPicker.ColorName;
            TextBlock3.Text = colorPicker.Color.ToString();
            TextBlock4.Text = colorPicker.Color.ScR.ToString();
            byte r = colorPicker.Color.R;
            byte g = colorPicker.Color.G;
            byte b = colorPicker.Color.B;

            s = colorPicker.Color.ToString();
            try
            {
                
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\asWorks.de\Terminverwaltung\Colors",true);
                key.SetValue("SetSelectedTerminBrushRed", r);
                key.SetValue("SetSelectedTerminBrushGreen", g);
                key.SetValue("SetSelectedTerminBrushBlue", b);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                MessageBox.Show(s);


            }


            //Color red = 0xff0000.Rgb();
            //string s = 0xff0000.ToString();

            //string s = key.GetValue("SetSelectedTerminBrush").ToString();
            //int i = int.Parse(s);

            //var b = i.Rgb();









        }

        private void ColorPicker1_SelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = d as ColorPicker;
            TextBlock1.Text = Syncfusion.Windows.Shared.ColorEdit.SuchColor(colorPicker.Color)[0];
        }
    }
}
