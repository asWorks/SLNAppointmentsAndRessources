using AppointmentsAndRessources.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AppointmentsAndRessources.Ressources
{
   public partial class UserControlWeekDay
    {

        public UserControlWeekDay()
        {
            InitializeComponent();
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            var dataObj = e.Data as DataObject;
            var dragged = dataObj.GetData(typeof(TerminDataViewModel)) as TerminDataViewModel;

            var v = this.Values;
            

            MessageBox.Show(dragged.Termin.ToString());

        }
    }
}
