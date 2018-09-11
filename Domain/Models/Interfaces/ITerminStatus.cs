using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
    public interface ITerminStatus
    {
        int ID { get; set; }
        string Status { get; set; }
}
}
