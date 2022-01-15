using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_Registro_Inicial
{
    /// <summary>
    /// Estatus_Registro_Inicial table
    /// </summary>
    public class Estatus_Registro_Inicial: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

