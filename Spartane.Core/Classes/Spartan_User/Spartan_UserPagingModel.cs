﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Spartan_User
{
    public class Spartan_UserPagingModel
    {
        public List<Spartane.Core.Classes.Spartan_User.Spartan_User> Spartan_Users { set; get; }
        public int RowCount { set; get; }
    }
}
