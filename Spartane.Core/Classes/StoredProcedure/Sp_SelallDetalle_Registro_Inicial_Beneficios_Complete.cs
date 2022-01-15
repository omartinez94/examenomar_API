using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Registro_Inicial_Beneficios_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public int ID_Registro_Inicial { get; set; }
        public int? Beneficio { get; set; }
        public string Beneficio_Descripcion { get; set; }
        public short? Rango_de_valor { get; set; }

    }
}
