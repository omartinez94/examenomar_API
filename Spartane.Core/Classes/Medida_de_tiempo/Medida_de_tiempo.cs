using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Medida_de_tiempo
{
    /// <summary>
    /// Medida_de_tiempo table
    /// </summary>
    public class Medida_de_tiempo: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

