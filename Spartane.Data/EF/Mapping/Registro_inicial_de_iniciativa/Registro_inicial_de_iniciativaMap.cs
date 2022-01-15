using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_inicial_de_iniciativa
{
    public partial class Registro_inicial_de_iniciativaMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa>
    {
        public Registro_inicial_de_iniciativaMap()
        {
            this.ToTable("Registro_inicial_de_iniciativa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
