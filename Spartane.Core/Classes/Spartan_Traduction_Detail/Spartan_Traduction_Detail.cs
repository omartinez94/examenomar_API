﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Traduction_Process;
using Spartane.Core.Classes.Spartan_Traduction_Concept_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Traduction_Detail
{
    /// <summary>
    /// Spartan_Traduction_Detail table
    /// </summary>
    public class Spartan_Traduction_Detail: BaseEntity
    {
        public int IdTraductionDetail { get; set; }
        public int? Spartan_Traduction_Process { get; set; }
        public int? Concept { get; set; }
        public int? IdConcept { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }

        [ForeignKey("Spartan_Traduction_Process")]
        public virtual Spartane.Core.Classes.Spartan_Traduction_Process.Spartan_Traduction_Process Spartan_Traduction_Process_Spartan_Traduction_Process { get; set; }
        [ForeignKey("Concept")]
        public virtual Spartane.Core.Classes.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type Concept_Spartan_Traduction_Concept_Type { get; set; }

    }
}

