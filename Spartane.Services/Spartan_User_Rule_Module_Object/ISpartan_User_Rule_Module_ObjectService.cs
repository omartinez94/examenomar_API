﻿using System;
using Spartane.Core.Classes.Spartan_User_Rule_Module_Object;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_User_Rule_Module_Object
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Rule_Module_ObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object GetByKey(int? Key, Boolean ConRelaciones);
        //Added parameter SpartanUserRole
        bool Delete(int? Key, int spartanUserRole);
        Int32 Insert(Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object entity);
        Int32 Update(Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object entity);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
