using System;
using Spartane.Core.Classes.Estatus_Registro_Inicial;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_Registro_Inicial
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_Registro_InicialService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial entity);
        Int32 Update(Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial entity);
        IList<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_InicialPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial entity);

    }
}
