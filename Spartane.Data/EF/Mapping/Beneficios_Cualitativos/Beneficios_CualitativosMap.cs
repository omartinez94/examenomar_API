using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Beneficios_Cualitativos
{
    public partial class Beneficios_CualitativosMap : EntityTypeConfiguration<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos>
    {
        public Beneficios_CualitativosMap()
        {
            this.ToTable("Beneficios_Cualitativos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
