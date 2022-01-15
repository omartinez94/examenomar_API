using System;
using Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Registro_Inicial_Prioridad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Registro_Inicial_PrioridadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad entity);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_PrioridadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad entity);

    }
}
