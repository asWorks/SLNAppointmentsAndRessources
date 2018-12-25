using AppointmentsAndRessources.Interfaces;
using Caliburn.Micro;
using Domain.Models;
using MySQL_Dal_CodeFirst;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.ViewModels
{
    [Export(typeof(ITestPeopleViewModel))]
   public class TestPeopleViewModel:Screen,ITestPeopleViewModel
    {

        private AppointmensModel _db;
        List<TestPeopleX> ListeLeute;

        public TestPeopleViewModel()
        {
            _db = new AppointmensModel();
            var ListeLeute = _db.PeopleTest;
            Leute = new ObservableCollection<TestPeopleX>(ListeLeute);


          ////  var p = new TestPeopleX{ ForeName = "Test", LastName = "Test" };
          ////  _db.PeopleTest.Add(p);
          //////Leute.Add(p);
          ////   _db.ChangeTracker.DetectChanges();
          ////  int rs = _db.SaveChanges();
          ////  Info = rs.ToString();
        }

        private ObservableCollection<TestPeopleX> _Leute;
        public ObservableCollection<TestPeopleX> Leute
        {
            get { return _Leute; }
            set
            {
                if (value != _Leute)
                {
                    _Leute = value;
                    NotifyOfPropertyChange(() => Leute);
                    //  isDirty = true;
                }
            }
        }


        private string _Info;
        public string Info
        {
            get { return _Info; }
            set
            {
                if (value != _Info)
                {
                    _Info = value;
                    NotifyOfPropertyChange(() => Info);
                    //  isDirty = true;
                }
            }
        }

       public void Test()
        {
            _db.SaveChanges();
        }

      public  void AddNew()
        {
            var p = new TestPeopleX { ForeName = "Test", LastName = "Testxxxxx" };
            _db.PeopleTest.Add(p);
            ///Leute.Add(p);
        }
    }
}
