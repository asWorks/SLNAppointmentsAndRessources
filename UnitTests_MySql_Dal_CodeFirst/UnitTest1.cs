using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySQL_Dal_CodeFirst;
using Domain.Models;
using MySQL_Dal;
using System.Collections;
using System.Linq;

namespace UnitTests_MySql_Dal_CodeFirst
{
    [TestClass]
    public class CreateDBandTables
    {
        //[TestMethod]
        //public void CreateDatabase()
        //{
        //    using (var db = new AppointmensModel())
        //    {
        //        var ap = new TerminData{ ID = "test", PatientenName = "Arpad Stöver", Behandler = "Mariann", Termin = new DateTime(2018, 02, 23, 8, 45, 0)};
        //        db.Termine.Add(ap);
        //        db.SaveChanges();
        //    }
        //}

        [TestMethod]
        public void TestDBAccess()
        {
            using (var db = new AppointmensModel())
            {
             var query = db.Termine;
               
                Assert.AreEqual(query.Count(), 1);

                var t = db.Termine.Where(e => e.ID == 1).SingleOrDefault();
                if (t !=null)
                {
                    db.Termine.Remove(t);

                }

                var ap = new TerminData { ID = 1, PatientenName = "Arpad Stöver", Behandler = "Mariann", Termin = DateTime.Now };
                db.Termine.Add(ap);
                db.SaveChanges();
            }
        }
    }
}
