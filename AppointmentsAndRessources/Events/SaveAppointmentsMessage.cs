using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsAndRessources.Events
{
  public  class SaveAppointmentsMessage
    {

        public bool DoAskBeforeSave { get; set; }
        public SaveAppointmentsMessage(bool askBeforeSaving)
        {
            DoAskBeforeSave = askBeforeSaving;
        }
    }
}
