﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Registro_Inicial_Prioridad_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int ID_Registro_Inicial { get; set; }
        public int? Prioridad_Estrategica { get; set; }
        public string Prioridad_Estrategica_Descripcion { get; set; }
        public int? Archivo_1 { get; set; }
        public int? Archivo_2 { get; set; }

    }
}
