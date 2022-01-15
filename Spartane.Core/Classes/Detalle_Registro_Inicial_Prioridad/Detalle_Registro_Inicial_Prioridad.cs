using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_inicial_de_iniciativa;
using Spartane.Core.Classes.Prioridades_Estrategicas;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad
{
    /// <summary>
    /// Detalle_Registro_Inicial_Prioridad table
    /// </summary>
    public class Detalle_Registro_Inicial_Prioridad: BaseEntity
    {
        public int Clave { get; set; }
        public int? ID_Registro_Inicial { get; set; }
        public int? Prioridad_Estrategica { get; set; }
        public int? Archivo_1 { get; set; }
        public string Archivo_1_URL { get; set; }
        public int? Archivo_2 { get; set; }
        public string Archivo_2_URL { get; set; }

        [ForeignKey("ID_Registro_Inicial")]
        public virtual Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa ID_Registro_Inicial_Registro_inicial_de_iniciativa { get; set; }
        [ForeignKey("Prioridad_Estrategica")]
        public virtual Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas Prioridad_Estrategica_Prioridades_Estrategicas { get; set; }
        [ForeignKey("Archivo_1")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_1_Spartane_File { get; set; }
        [ForeignKey("Archivo_2")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_2_Spartane_File { get; set; }

    }
}

