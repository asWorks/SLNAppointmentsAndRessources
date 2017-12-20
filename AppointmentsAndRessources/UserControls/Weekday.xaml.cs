﻿using System;
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
    /// Interaction logic for Weekday.xaml
    /// </summary>
    public partial class Weekday : UserControl
    {
        public Weekday()
        {
            InitializeComponent();
            SetRessource();

        }

        
        void SetRessource()
        {

            var templ = (DataTemplate)this.MainGrid.FindResource("TermineDataUCFullTemplate");
            WeekdayListBox.ItemTemplate = templ;

        }
    }
}
