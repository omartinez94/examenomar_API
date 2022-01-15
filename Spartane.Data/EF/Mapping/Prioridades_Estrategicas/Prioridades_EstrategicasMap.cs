using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Prioridades_Estrategicas
{
    public partial class Prioridades_EstrategicasMap : EntityTypeConfiguration<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas>
    {
        public Prioridades_EstrategicasMap()
        {
            this.ToTable("Prioridades_Estrategicas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
