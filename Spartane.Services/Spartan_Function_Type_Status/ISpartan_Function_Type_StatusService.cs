﻿using System;
using Spartane.Core.Classes.Spartan_Function_Type_Status;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_Function_Type_Status
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Function_Type_StatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status GetByKey(short? Key, Boolean ConRelaciones);
        bool Delete(short? Key);
        Int32 Insert(Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status entity);
        Int32 Update(Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status entity);
        IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_Function_Type_Status.Spartan_Function_Type_Status> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
