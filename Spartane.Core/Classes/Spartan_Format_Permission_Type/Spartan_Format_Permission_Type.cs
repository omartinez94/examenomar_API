﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Format_Permission_Type
{
    /// <summary>
    /// Spartan_Format_Permission_Type table
    /// </summary>
    public class Spartan_Format_Permission_Type: BaseEntity
    {
        public short PermissionTypeId { get; set; }
        public string Description { get; set; }


    }
}

