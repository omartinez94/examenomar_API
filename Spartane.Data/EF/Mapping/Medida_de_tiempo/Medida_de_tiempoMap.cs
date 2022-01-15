using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Medida_de_tiempo
{
    public partial class Medida_de_tiempoMap : EntityTypeConfiguration<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo>
    {
        public Medida_de_tiempoMap()
        {
            this.ToTable("Medida_de_tiempo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
