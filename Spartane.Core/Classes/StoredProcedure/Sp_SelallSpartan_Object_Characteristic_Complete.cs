﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Object_Characteristic_Complete : BaseEntity
    {
        public short Object_Characteristc_Id { get; set; }
        public string Description { get; set; }
        public int? Attribute_Type { get; set; }
        public string Attribute_Type_Description { get; set; }

    }
}
