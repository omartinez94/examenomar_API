﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Object_Config : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Object_Config_Object_Config_Id { get; set; }
        public string Spartan_Object_Config_Description { get; set; }

    }
}
