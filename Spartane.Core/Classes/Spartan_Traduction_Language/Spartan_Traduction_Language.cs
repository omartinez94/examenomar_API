﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Traduction_Language
{
    /// <summary>
    /// Spartan_Traduction_Language table
    /// </summary>
    public class Spartan_Traduction_Language: BaseEntity
    {
        public int IdLanguage { get; set; }
        public string LanguageT { get; set; }


    }
}

