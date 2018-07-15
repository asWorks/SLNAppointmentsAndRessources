using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;

namespace UnitTestsServices
{
    [TestClass]
    public class TestsAppointmentService
    {
        [TestMethod]
        public void TestGetWeeknumber()
        {
           
            int res = DateTimeServices.GetWeekNumber();
            Assert.AreEqual(res, 28);
        }


        [TestMethod]
        public void TestGetDateForWeekNumber()
        {
          
            DateTime dt = DateTimeServices.FromIso8601Weeknumber(29);
            Assert.AreEqual(dt, new DateTime(2018,7,16));
        }

        [TestMethod]
        public void TestMeasureTimeToGenerate()
        {
            var asx = new Services.AppointmentDataService();

            Stopwatch sw = new Stopwatch();
            sw.Restart();
            var x = asx.GetTerminListe(new DateTime(2018, 11, 18));

            sw.Stop();
            var res = sw.ElapsedMilliseconds;
            var X = res;

        }
    }
}
