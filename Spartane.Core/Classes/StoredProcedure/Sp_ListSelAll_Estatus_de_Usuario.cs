using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_de_Usuario : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_de_Usuario_Clave { get; set; }
        public string Estatus_de_Usuario_Descripcion { get; set; }

    }
}
