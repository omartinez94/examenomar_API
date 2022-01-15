using System;
using Spartane.Core.Classes.Medida_de_tiempo;
using System.Collections.Generic;


namespace Spartane.Services.Medida_de_tiempo
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMedida_de_tiempoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo entity);
        Int32 Update(Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo entity);
        IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo entity);

    }
}
