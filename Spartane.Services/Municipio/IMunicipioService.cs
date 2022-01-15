using System;
using Spartane.Core.Classes.Municipio;
using System.Collections.Generic;


namespace Spartane.Services.Municipio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMunicipioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Municipio.Municipio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Municipio.Municipio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Municipio.Municipio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Municipio.Municipio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Municipio.Municipio entity);
        Int32 Update(Spartane.Core.Classes.Municipio.Municipio entity);
        IList<Spartane.Core.Classes.Municipio.Municipio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Municipio.Municipio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Municipio.MunicipioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Municipio.Municipio> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Municipio.Municipio entity);

    }
}
