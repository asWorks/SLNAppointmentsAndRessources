using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class DragDropPatientenInfo
    {
        public int PatientenId { get; set; }
        public string PatientenFullName { get; set; }

        public DragDropPatientenInfo(int Id,string Nachname,string Vorname)    
        {
            PatientenId = Id;
            PatientenFullName = string.Format("{0} {1}", Vorname, Nachname);
        }

        public DragDropPatientenInfo(MySQL_Dal.pat5 patient):this(patient.id,patient.V_NAME,patient.N_NAME)
        {
            
        }


    }
}
