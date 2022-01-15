using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallEstado_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Pais { get; set; }
        public string Pais_Nombre { get; set; }

    }
}
