﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Favorite_Object_Complete : BaseEntity
    {
        public int User_Favorite_Object_Id { get; set; }
        public int? User_Id { get; set; }
        public string User_Id_Name { get; set; }
        public int? Object { get; set; }
        public string Object_Name { get; set; }
        public short? Order_Shown { get; set; }

    }
}
