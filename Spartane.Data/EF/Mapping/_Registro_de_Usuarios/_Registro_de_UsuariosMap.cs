using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping._Registro_de_Usuarios
{
    public partial class _Registro_de_UsuariosMap : EntityTypeConfiguration<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios>
    {
        public _Registro_de_UsuariosMap()
        {
            this.ToTable("_Registro_de_Usuarios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
