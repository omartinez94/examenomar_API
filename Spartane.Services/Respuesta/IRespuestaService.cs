using System;
using Spartane.Core.Classes.Respuesta;
using System.Collections.Generic;


namespace Spartane.Services.Respuesta
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRespuestaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Respuesta.Respuesta> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Respuesta.Respuesta> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Respuesta.Respuesta> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Respuesta.Respuesta GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Respuesta.Respuesta entity);
        Int32 Update(Spartane.Core.Classes.Respuesta.Respuesta entity);
        IList<Spartane.Core.Classes.Respuesta.Respuesta> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Respuesta.Respuesta> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Respuesta.RespuestaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Respuesta.Respuesta> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Respuesta.Respuesta entity);

    }
}
