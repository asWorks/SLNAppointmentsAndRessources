﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Interfaces
{
  public  interface ITerminType
    {
        int value { get; set; }
        string DisplayName{ get; set; }

    }
}