using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEstatus_Registro_Inicial : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Estatus_Registro_Inicial_Clave { get; set; }
        public string Estatus_Registro_Inicial_Descripcion { get; set; }

    }
}
