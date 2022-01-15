using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_KPIs_Impactados
{
    public partial class MS_KPIs_ImpactadosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados>
    {
        public MS_KPIs_ImpactadosMap()
        {
            this.ToTable("MS_KPIs_Impactados");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
