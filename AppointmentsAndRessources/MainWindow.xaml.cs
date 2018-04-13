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
using AppointmentsAndRessourses.ViewModels;

namespace TestTerminplanung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WeekDayViewModel vModel;
       
        public MainWindow()
        {
            InitializeComponent();

            //vModel = new WeekDayViewModel();
            //this.DataContext = vModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vModel.addTerminData();
        }
    }
}
