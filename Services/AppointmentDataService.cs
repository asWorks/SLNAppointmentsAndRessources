using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Dal.Repositories;
using MySQL_Dal;
using MySQL_Dal_CodeFirst;
using System.Globalization;
using System.Windows.Input;


namespace Services
{
    public class AppointmentDataService
    {
        DbContext _TherapiContext;
        DbContext _AppointmentContext;

        public AppointmentDataService()
        {
            _TherapiContext = new MySQL_Dal.GuesterModel();
            _AppointmentContext = new MySQL_Dal_CodeFirst.AppointmensModel();
        }

        private List<Domain.Models.TerminData> terminListe { get; set; }


        public async Task<List<Domain.Models.TerminData>> GetTerminListe(DateTime ForDate)
        {

            DateTime VonDatum = SetTimeForDate(ForDate, 8, 0, 0);
            DateTime BisDatum = SetTimeForDate(ForDate, 23, 59, 59);

            var AppRepo = new GenericRepository<TerminData>(_AppointmentContext);

            //terminListe = await AppRepo.FindByWithTrackingAsync(n => n.Termin >= VonDatum && n.Termin <= BisDatum).Result.ToList();
            var tl = await AppRepo.FindByWithTrackingAsync(n => n.Termin >= VonDatum && n.Termin <= BisDatum);

            terminListe = tl.ToList();

            if (!terminListe.Any())
            {

                terminListe = await GenerateTermineAsync(ForDate);
            }

            return terminListe.ToList();





        }

        public int SaveAppointments()
        {
            return _AppointmentContext.SaveChanges();

        }

        public async Task<List<TerminData>> GenerateTermineAsync(DateTime forDate)
        {

            try
            {
               // var x = Task.Factory.StartNew((p) => GenerateTermine((DateTime)p), forDate);
                 await Task.Factory.StartNew((p) => TestAsync((DateTime)p), forDate);
                return  null;
            
            }
            catch (Exception)
            {

                throw;
            }







        }

        private void TestAsync(DateTime dt)
        {

            Task.Delay(2500);

            return;
        }

        private List<TerminData> GenerateTermine(DateTime forDate)
        {

            List<TerminData> buffer = new List<TerminData>();

            if (forDate.IstFeiertag())
            {
                return buffer;
            }

            var BehRepo = new GenericRepository<kollegen2>(_TherapiContext);
            var AppRepo = new GenericRepository<TerminData>(_AppointmentContext);



            var behandler = BehRepo.All();

            DateTime dt = SetTimeForDate(forDate, 8, 0, 0);

            for (int i = 0; i < 16; i++)
            {
                foreach (var item in behandler)
                {
                    var t = new TerminData();
                    t.Termin = dt;
                    t.BehandlerID = item.ID;
                    t.Behandler = string.Format("{0} {1}", item.VORNAME, item.NACHNAME);
                    t.PatientenID = 0;
                    t.PatientenName = "Freier Termin";
                    t.Mandant = MandatenService.GetCurrentMandant();
                    t.Memo = "";
                    t.RezeptID = 0;
                    t.istVergeben = false;
                    t.istAusgeführt = false;
                    AppRepo.Insert(t);
                    buffer.Add(t);
                }

                dt = dt.AddMinutes(30);
            }

            return buffer;

        }

        DateTime SetTimeForDate(DateTime Datum, int hour, int minute, int second)
        {

            DateTime Neu = new DateTime(Datum.Year, Datum.Month, Datum.Day, hour, minute, second);

            return Neu;

        }

        List<DateTime> GetWeekDates(int weeknumber)
        {


            return null;

        }


    }
}
;