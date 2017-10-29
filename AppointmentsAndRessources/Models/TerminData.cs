using System;

namespace AppointmentsAndRessourses.Models
{
    public class TerminData
    {
        public string PatientenName { get; set; }       
        public string Behandler { get; set; }

        public DateTime Termin { get; set; }

        public string ID { get; set; }
    }
}