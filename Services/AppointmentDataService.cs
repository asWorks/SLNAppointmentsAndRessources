using Dal.Repositories;
using Domain.Models;
using MySQL_Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace Services
{
    public class AppointmentDataService
    {
        public enum GenerateAppointmentResult
        {
            Success,
            NoData,
            NoWorkingDay,
            Failure
        }

        private DbContext _TherapiContext;
        private DbContext _AppointmentContext;

        public AppointmentDataService()
        {
            _TherapiContext = new MySQL_Dal.GuesterModel();
            _AppointmentContext = new MySQL_Dal_CodeFirst.AppointmensModel();
        }

        private List<Domain.Models.TerminData> terminListe { get; set; }


        public async Task<List<Domain.Models.TerminData>> GetTerminListe(DateTime ForDate)
        {
            // https://stackoverflow.com/questions/38717533/mvvm-async-await-pattern

            DateTime VonDatum = SetTimeForDate(ForDate, 8, 0, 0);
            DateTime BisDatum = SetTimeForDate(ForDate, 23, 59, 59);

            var AppRepo = new GenericRepository<TerminData>(_AppointmentContext);

            //terminListe = await AppRepo.FindByWithTrackingAsync(n => n.Termin >= VonDatum && n.Termin <= BisDatum).Result.ToList();
            var tl = await AppRepo.FindByWithTrackingAsync(n => n.Termin >= VonDatum && n.Termin <= BisDatum);
           // var tl = _AppointmentContext(n => n.Termin >= VonDatum && n.Termin <= BisDatum);


            terminListe = tl.ToList();

            if (!terminListe.Any())
            {
                try
                {
                    var res = await GenerateTermineAsync(ForDate);                 //Context.SaveChanges funktioniert nicht wie erwartet. Prüfen
                    //if (res == GenerateAppointmentResult.Success)
                    //{
                        var t2 = await AppRepo.FindByWithTrackingAsync(n => n.Termin >= VonDatum && n.Termin <= BisDatum);
                        terminListe = t2.ToList();
                    //}
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return terminListe;





        }

        public int SaveAppointments()
        {
            return _AppointmentContext.SaveChanges();

        }

        public async Task<GenerateAppointmentResult> GenerateTermineAsync(DateTime forDate)
        {

            try
            {
                var x = await Task.Factory.StartNew((p) => GenerateTermine((DateTime)p), forDate);

                return x;

            }
            catch (Exception)
            {

                throw;
            }



        }


        private GenerateAppointmentResult GenerateTermine(DateTime forDate)
        {
            try
            {
                List<TerminData> buffer = new List<TerminData>();

                if (forDate.IstFeiertag())
                {
                    return GenerateAppointmentResult.NoWorkingDay;
                }

                var BehRepo = new GenericRepository<kollegen2>(_TherapiContext);
                var AppRepo = new GenericRepository<TerminData>(_AppointmentContext);



                var behandler = BehRepo.All();

                DateTime dt = SetTimeForDate(forDate, 8, 0, 0);

                for (int i = 0; i <= 16; i++)
                {

                    var t = new TerminData();
                    t.Termin = dt;
                    t.BehandlerPatientenTermine = new List<BehandlerPatientenTermin>();
                    int man = MandatenService.GetCurrentMandant();

                    foreach (var b in behandler)
                    {
                        var bpt = new BehandlerPatientenTermin(dt, b.ID, 0, b.VORNAME, b.NACHNAME,"Nicht","vergeben",
                                                               man, 0, false, false);


                        t.BehandlerPatientenTermine.Add(bpt);

                        //buffer.Add(t);
                    }
                    AppRepo.Insert(t);
                    dt = dt.AddMinutes(30);
                }

                if (SaveAppointments() > 0)
                {
                    return GenerateAppointmentResult.Success;
                }
                else
                {
                    return GenerateAppointmentResult.Failure;
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        private DateTime SetTimeForDate(DateTime Datum, int hour, int minute, int second)
        {

            DateTime Neu = new DateTime(Datum.Year, Datum.Month, Datum.Day, hour, minute, second);

            return Neu;

        }

        private List<DateTime> GetWeekDates(int weeknumber)
        {


            return null;

        }


    }
}
;