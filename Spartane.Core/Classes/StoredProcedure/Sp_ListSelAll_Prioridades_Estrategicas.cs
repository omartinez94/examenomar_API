using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPrioridades_Estrategicas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Prioridades_Estrategicas_Clave { get; set; }
        public string Prioridades_Estrategicas_Descripcion { get; set; }

    }
}
