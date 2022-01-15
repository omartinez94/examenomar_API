using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Respuesta
{
    public class RespuestaPagingModel
    {
        public List<Spartane.Core.Classes.Respuesta.Respuesta> Respuestas { set; get; }
        public int RowCount { set; get; }
    }
}
