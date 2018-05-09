using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace AppointmentsAndRessources.Events
{
    public class PatientenInfoChangedMessage
    {

        public DragDropPatientenInfo patientenInfo { get; set; }
        public int TerminId { get; set; }
        public bool isInValidState { get; set; }

        public PatientenInfoChangedMessage(DragDropPatientenInfo ddPatInfo,bool isValid,int terminId)
        {
            patientenInfo = ddPatInfo;
            isInValidState = isValid;
            TerminId = terminId;
        }

    }
}
