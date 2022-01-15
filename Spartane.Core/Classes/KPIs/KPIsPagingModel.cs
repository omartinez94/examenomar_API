using System;  
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.KPIs
{
    public class KPIsPagingModel
    {
        public List<Spartane.Core.Classes.KPIs.KPIs> KPIss { set; get; }
        public int RowCount { set; get; }
    }
}
