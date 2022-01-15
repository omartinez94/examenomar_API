using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Registro_Inicial_Prioridad : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Registro_Inicial_Prioridad_Clave { get; set; }
        public int Detalle_Registro_Inicial_Prioridad_ID_Registro_Inicial { get; set; }
        public int? Detalle_Registro_Inicial_Prioridad_Prioridad_Estrategica { get; set; }
        public string Detalle_Registro_Inicial_Prioridad_Prioridad_Estrategica_Descripcion { get; set; }
        public int? Detalle_Registro_Inicial_Prioridad_Archivo_1 { get; set; }
        public string Detalle_Registro_Inicial_Prioridad_Archivo_1_Nombre { get; set; }
        public int? Detalle_Registro_Inicial_Prioridad_Archivo_2 { get; set; }
        public string Detalle_Registro_Inicial_Prioridad_Archivo_2_Nombre { get; set; }

    }
}
