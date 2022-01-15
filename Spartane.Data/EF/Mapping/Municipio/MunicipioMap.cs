using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Municipio
{
    public partial class MunicipioMap : EntityTypeConfiguration<Spartane.Core.Classes.Municipio.Municipio>
    {
        public MunicipioMap()
        {
            this.ToTable("Municipio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
