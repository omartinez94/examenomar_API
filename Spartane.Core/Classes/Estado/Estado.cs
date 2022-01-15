using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pais;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estado
{
    /// <summary>
    /// Estado table
    /// </summary>
    public class Estado: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Pais { get; set; }

        [ForeignKey("Pais")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_Pais { get; set; }

    }
}

