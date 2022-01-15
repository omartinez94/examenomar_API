using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllKPIs : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int KPIs_Clave { get; set; }
        public string KPIs_Descripcion { get; set; }

    }
}
