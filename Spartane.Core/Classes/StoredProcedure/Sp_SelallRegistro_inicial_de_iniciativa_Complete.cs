using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_inicial_de_iniciativa_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_de_la_iniciativa { get; set; }
        public string Iniciales { get; set; }
        public string Folio { get; set; }
        public decimal? BNEA_aprobado { get; set; }
        public string Folio_fase { get; set; }
        public decimal? Avance_Fase { get; set; }
        public string Cronograma { get; set; }
        public decimal? Avance_de_la_Iniciativa { get; set; }
        public decimal? Calificacion { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
