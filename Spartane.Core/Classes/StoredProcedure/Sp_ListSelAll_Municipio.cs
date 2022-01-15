using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMunicipio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Municipio_Clave { get; set; }
        public string Municipio_Nombre { get; set; }
        public int? Municipio_Estado { get; set; }
        public string Municipio_Estado_Nombre { get; set; }

    }
}
