using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_de_Usuario
{
    public partial class Estatus_de_UsuarioMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario>
    {
        public Estatus_de_UsuarioMap()
        {
            this.ToTable("Estatus_de_Usuario");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
