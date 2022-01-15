using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Estatus_Registro_Inicial
{
    public partial class Estatus_Registro_InicialMap : EntityTypeConfiguration<Spartane.Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial>
    {
        public Estatus_Registro_InicialMap()
        {
            this.ToTable("Estatus_Registro_Inicial");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
