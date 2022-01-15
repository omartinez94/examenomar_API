using System;
using Spartane.Core.Classes.Registro_inicial_de_iniciativa;
using System.Collections.Generic;


namespace Spartane.Services.Registro_inicial_de_iniciativa
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistro_inicial_de_iniciativaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity);
        Int32 Update(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity);
        IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Captura_Enlace_PMO(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity);
       int Update_Captura_Mensual_de_Usuario_Enlace_y_PMO(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity);
       int Update_Formulado(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity);
       int Update_Responsable_de_Alineacion(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity);

    }
}
