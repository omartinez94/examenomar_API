﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_BR_Status
{
    /// <summary>
    /// Spartan_BR_Status table
    /// </summary>
    public class Spartan_BR_Status: BaseEntity
    {
        public short StatusId { get; set; }
        public string Description { get; set; }


    }
}

