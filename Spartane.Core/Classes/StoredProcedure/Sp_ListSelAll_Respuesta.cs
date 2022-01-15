using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRespuesta : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Respuesta_Clave { get; set; }
        public string Respuesta_Descripcion { get; set; }

    }
}
