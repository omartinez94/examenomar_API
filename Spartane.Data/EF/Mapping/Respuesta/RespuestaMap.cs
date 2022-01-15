using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Respuesta
{
    public partial class RespuestaMap : EntityTypeConfiguration<Spartane.Core.Classes.Respuesta.Respuesta>
    {
        public RespuestaMap()
        {
            this.ToTable("Respuesta");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
