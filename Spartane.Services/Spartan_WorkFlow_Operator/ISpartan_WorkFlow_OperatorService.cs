﻿using System;
using Spartane.Core.Classes.Spartan_WorkFlow_Operator;
using System.Collections.Generic;


namespace Spartane.Services.Spartan_WorkFlow_Operator
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_OperatorService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key);
        Int16 Insert(Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator entity);
        Int16 Update(Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator entity);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_OperatorPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Spartan_WorkFlow_Operator.Spartan_WorkFlow_Operator> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
