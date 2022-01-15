﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Function_Status
{
    /// <summary>
    /// Spartan_Function_Status table
    /// </summary>
    public class Spartan_Function_Status: BaseEntity
    {
        public short Function_Status_Id { get; set; }
        public string Description { get; set; }


    }
}

