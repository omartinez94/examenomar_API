﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMunicipio_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }
        public string Estado_Nombre { get; set; }

    }
}
