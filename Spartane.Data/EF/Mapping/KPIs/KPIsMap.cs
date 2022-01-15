using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.KPIs
{
    public partial class KPIsMap : EntityTypeConfiguration<Spartane.Core.Classes.KPIs.KPIs>
    {
        public KPIsMap()
        {
            this.ToTable("KPIs");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
