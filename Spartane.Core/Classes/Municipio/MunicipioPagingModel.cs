using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Municipio
{
    public class MunicipioPagingModel
    {
        public List<Spartane.Core.Classes.Municipio.Municipio> Municipios { set; get; }
        public int RowCount { set; get; }
    }
}
