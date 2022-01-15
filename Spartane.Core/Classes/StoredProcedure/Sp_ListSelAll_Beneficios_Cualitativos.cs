using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllBeneficios_Cualitativos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Beneficios_Cualitativos_Clave { get; set; }
        public string Beneficios_Cualitativos_Descripcion { get; set; }

    }
}
