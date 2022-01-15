﻿using System;
using Spartane.Core.Classes.Spartan_Format_Permission_Type;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Format_Permission_Type
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_Permission_TypeService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type entity);
        Int16 Update(Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type entity);
        IList<Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_TypePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Format_Permission_Type.Spartan_Format_Permission_Type> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
