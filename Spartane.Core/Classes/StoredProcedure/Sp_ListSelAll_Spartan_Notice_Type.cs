using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Notice_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Notice_Type_Notice_Type_Id { get; set; }
        public string Spartan_Notice_Type_Description { get; set; }

    }
}
