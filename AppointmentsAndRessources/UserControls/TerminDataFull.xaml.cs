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

namespace AppointmentsAndRessources.UserControls
{
    /// <summary>
    /// Interaction logic for TerminData.xaml
    /// </summary>
    public partial class TerminDataFull : UserControl
    {
        public TerminDataFull()
        {
            InitializeComponent();
        }


        private void ListView_Drop(object sender, DragEventArgs e)
        {

            var dataObj = e.Data as DataObject;
            var dragged = dataObj.GetData(typeof(TerminDataViewModel)) as TerminDataViewModel;

            var v = (TerminDataViewModel)this.DataContext;

            v.PatientenName = dragged.PatientenName;
            v.isSelected = true;


           // MessageBox.Show(dragged.PatientenName);

        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var v = (TerminDataViewModel)this.DataContext;

           // v.PatientenName = dragged.PatientenName;
            v.isSelected = !v.isSelected;
        }
    }
}
