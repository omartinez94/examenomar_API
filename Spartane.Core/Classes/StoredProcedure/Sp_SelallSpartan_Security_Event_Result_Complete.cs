using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Security_Event_Result_Complete : BaseEntity
    {
        public short Security_Event_Result_Id { get; set; }
        public string Description { get; set; }

    }
}
