using System;
using Spartane.Core.Classes.Prioridades_Estrategicas;
using System.Collections.Generic;


namespace Spartane.Services.Prioridades_Estrategicas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPrioridades_EstrategicasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas entity);
        Int32 Update(Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas entity);
        IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_EstrategicasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas entity);

    }
}
