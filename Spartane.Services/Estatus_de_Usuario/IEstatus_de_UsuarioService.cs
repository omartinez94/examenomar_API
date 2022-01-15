using System;
using Spartane.Core.Classes.Estatus_de_Usuario;
using System.Collections.Generic;


namespace Spartane.Services.Estatus_de_Usuario
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_de_UsuarioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario entity);
        Int32 Update(Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario entity);
        IList<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_UsuarioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario entity);

    }
}
