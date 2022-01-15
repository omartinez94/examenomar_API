using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Estatus_Registro_Inicial;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Registro_inicial_de_iniciativa
{
    /// <summary>
    /// Registro_inicial_de_iniciativa table
    /// </summary>
    public class Registro_inicial_de_iniciativa: BaseEntity
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

        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial Estatus_Estatus_Registro_Inicial { get; set; }

    }
}

