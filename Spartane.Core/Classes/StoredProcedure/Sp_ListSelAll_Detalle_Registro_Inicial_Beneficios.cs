using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Registro_Inicial_Beneficios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Registro_Inicial_Beneficios_Clave { get; set; }
        public int Detalle_Registro_Inicial_Beneficios_ID_Registro_Inicial { get; set; }
        public int? Detalle_Registro_Inicial_Beneficios_Beneficio { get; set; }
        public string Detalle_Registro_Inicial_Beneficios_Beneficio_Descripcion { get; set; }
        public short? Detalle_Registro_Inicial_Beneficios_Rango_de_valor { get; set; }

    }
}
