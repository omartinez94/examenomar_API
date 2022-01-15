using System;
using Spartane.Core.Classes._Registro_de_Usuarios;
using System.Collections.Generic;


namespace Spartane.Services._Registro_de_Usuarios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface I_Registro_de_UsuariosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity);
        Int32 Update(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity);
        IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_UsuariosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity);
       int Update_Domicilio(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity);
       int Update_Autorizacion(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity);

    }
}
