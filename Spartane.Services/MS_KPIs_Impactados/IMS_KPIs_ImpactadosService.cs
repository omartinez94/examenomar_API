using System;
using Spartane.Core.Classes.MS_KPIs_Impactados;
using System.Collections.Generic;


namespace Spartane.Services.MS_KPIs_Impactados
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMS_KPIs_ImpactadosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados entity);
        Int32 Update(Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados entity);
        IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_ImpactadosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados entity);

    }
}
