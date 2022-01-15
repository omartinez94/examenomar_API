using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_inicial_de_iniciativa;
using Spartane.Core.Classes.Beneficios_Cualitativos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios
{
    /// <summary>
    /// Detalle_Registro_Inicial_Beneficios table
    /// </summary>
    public class Detalle_Registro_Inicial_Beneficios: BaseEntity
    {
        public int Clave { get; set; }
        public int? ID_Registro_Inicial { get; set; }
        public int? Beneficio { get; set; }
        public short? Rango_de_valor { get; set; }

        [ForeignKey("ID_Registro_Inicial")]
        public virtual Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa ID_Registro_Inicial_Registro_inicial_de_iniciativa { get; set; }
        [ForeignKey("Beneficio")]
        public virtual Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos Beneficio_Beneficios_Cualitativos { get; set; }

    }
}

