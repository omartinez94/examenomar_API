using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Estado;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Municipio
{
    /// <summary>
    /// Municipio table
    /// </summary>
    public class Municipio: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Estado { get; set; }

        [ForeignKey("Estado")]
        public virtual Spartane.Core.Classes.Estado.Estado Estado_Estado { get; set; }

    }
}

