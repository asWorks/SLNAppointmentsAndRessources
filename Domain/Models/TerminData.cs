﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TerminData
    {


        public TerminData()
        {

        }
        public int ID { get; set; }
        public int PatientenID { get; set; }

        public string PatientenName { get; set; }

        public string Behandler { get; set; }

        public DateTime Termin { get; set; }




    }
}
