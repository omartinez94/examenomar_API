using System;
using Spartane.Core.Classes.KPIs;
using System.Collections.Generic;


namespace Spartane.Services.KPIs
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IKPIsService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.KPIs.KPIs> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.KPIs.KPIs> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.KPIs.KPIs> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.KPIs.KPIs GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.KPIs.KPIs entity);
        Int32 Update(Spartane.Core.Classes.KPIs.KPIs entity);
        IList<Spartane.Core.Classes.KPIs.KPIs> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.KPIs.KPIs> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.KPIs.KPIsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.KPIs.KPIs> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.KPIs.KPIs entity);

    }
}
