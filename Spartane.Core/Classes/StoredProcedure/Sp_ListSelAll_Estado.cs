using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstado : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estado_Clave { get; set; }
        public string Estado_Nombre { get; set; }
        public int? Estado_Pais { get; set; }
        public string Estado_Pais_Nombre { get; set; }

    }
}
