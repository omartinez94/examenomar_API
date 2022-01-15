using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMedida_de_tiempo : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Medida_de_tiempo_Clave { get; set; }
        public string Medida_de_tiempo_Descripcion { get; set; }

    }
}
