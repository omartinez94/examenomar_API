using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_KPIs_Impactados : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_KPIs_Impactados_Clave { get; set; }
        public int MS_KPIs_Impactados_ID_Registro_Inicial { get; set; }
        public int? MS_KPIs_Impactados_KPI { get; set; }
        public string MS_KPIs_Impactados_KPI_Descripcion { get; set; }

    }
}
