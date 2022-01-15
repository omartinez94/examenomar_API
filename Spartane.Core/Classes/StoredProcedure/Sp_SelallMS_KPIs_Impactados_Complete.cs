using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_KPIs_Impactados_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int ID_Registro_Inicial { get; set; }
        public int? KPI { get; set; }
        public string KPI_Descripcion { get; set; }

    }
}
