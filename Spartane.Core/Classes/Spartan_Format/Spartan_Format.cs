﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Format_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Format
{
    /// <summary>
    /// Spartan_Format table
    /// </summary>
    public class Spartan_Format: BaseEntity
    {
        public int FormatId { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? Registration_User { get; set; }
        public string Format_Name { get; set; }
        public short? Format_Type { get; set; }
        public string Search { get; set; }
        public int? Object { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string Filter { get; set; }

        [ForeignKey("Format_Type")]
        public virtual Spartane.Core.Classes.Spartan_Format_Type.Spartan_Format_Type Format_Type_Spartan_Format_Type { get; set; }

        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Spartan_Object_Spartan_Format_Object { get; set; }

        public virtual List<Spartane.Core.Classes.Spartan_Format_Field.Spartan_Format_Field> Format_Field_Spartan_Format_Field { get; set; }

        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Spartan_Format_User { get; set; }
        
    }
}

