using System;
using Spartane.Core.Classes.Beneficios_Cualitativos;
using System.Collections.Generic;


namespace Spartane.Services.Beneficios_Cualitativos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IBeneficios_CualitativosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos entity);
        Int32 Update(Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos entity);
        IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_CualitativosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos entity);

    }
}
