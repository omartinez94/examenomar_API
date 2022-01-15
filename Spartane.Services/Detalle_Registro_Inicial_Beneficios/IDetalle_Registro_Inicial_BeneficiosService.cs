using System;
using Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Registro_Inicial_Beneficios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Registro_Inicial_BeneficiosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios entity);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_BeneficiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios entity);

    }
}
