using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_inicial_de_iniciativa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_inicial_de_iniciativa_Clave { get; set; }
        public string Registro_inicial_de_iniciativa_Nombre_de_la_iniciativa { get; set; }
        public string Registro_inicial_de_iniciativa_Iniciales { get; set; }
        public string Registro_inicial_de_iniciativa_Folio { get; set; }
        public decimal? Registro_inicial_de_iniciativa_BNEA_aprobado { get; set; }
        public string Registro_inicial_de_iniciativa_Folio_fase { get; set; }
        public decimal? Registro_inicial_de_iniciativa_Avance_Fase { get; set; }
        public string Registro_inicial_de_iniciativa_Cronograma { get; set; }
        public decimal? Registro_inicial_de_iniciativa_Avance_de_la_Iniciativa { get; set; }
        public decimal? Registro_inicial_de_iniciativa_Calificacion { get; set; }
        public int? Registro_inicial_de_iniciativa_Estatus { get; set; }
        public string Registro_inicial_de_iniciativa_Estatus_Descripcion { get; set; }

    }
}
