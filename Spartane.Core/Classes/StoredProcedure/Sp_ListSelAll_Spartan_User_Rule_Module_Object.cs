using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Rule_Module_Object : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Rule_Module_Object_User_Rule_Module_Object_Id { get; set; }
        public short? Spartan_User_Rule_Module_Object_Module_Id { get; set; }
        public string Spartan_User_Rule_Module_Object_Module_Id_Name { get; set; }
        public int? Spartan_User_Rule_Module_Object_Object_Id { get; set; }
        public string Spartan_User_Rule_Module_Object_Object_Id_Name { get; set; }
        public short? Spartan_User_Rule_Module_Object_Order_Shown { get; set; }
        public int Spartan_User_Rule_Module_Object_Spartan_User_Role { get; set; }

    }
}
