﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_WorkFlow_Operator
{
    /// <summary>
    /// Spartan_WorkFlow_Operator table
    /// </summary>
    public class Spartan_WorkFlow_Operator: BaseEntity
    {
        public short OperatorId { get; set; }
        public string Description { get; set; }


    }
}

