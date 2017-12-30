﻿using AppointmentsAndRessourses.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{
   public class TermineEditViewModel:Screen
    {

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


        public TermineEditViewModel()
        {

            Wochentage = new ObservableCollection<WeekDayViewModel>();
            for (int i = 0; i < 20; i++)
            {
                var wt = new WeekDayViewModel();
                wt.Datum = DateTime.Now.AddDays(i).ToString();
                Wochentage.Add(wt);
            }
        }

    }
}
