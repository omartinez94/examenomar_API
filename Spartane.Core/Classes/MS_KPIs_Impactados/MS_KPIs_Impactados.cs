using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_inicial_de_iniciativa;
using Spartane.Core.Classes.KPIs;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_KPIs_Impactados
{
    /// <summary>
    /// MS_KPIs_Impactados table
    /// </summary>
    public class MS_KPIs_Impactados: BaseEntity
    {
        public int Clave { get; set; }
        public int? ID_Registro_Inicial { get; set; }
        public int? KPI { get; set; }

        [ForeignKey("ID_Registro_Inicial")]
        public virtual Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa ID_Registro_Inicial_Registro_inicial_de_iniciativa { get; set; }
        [ForeignKey("KPI")]
        public virtual Spartane.Core.Classes.KPIs.KPIs KPI_KPIs { get; set; }

    }
}

