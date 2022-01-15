using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Registro_Inicial_Prioridad
{
    public partial class Detalle_Registro_Inicial_PrioridadMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad>
    {
        public Detalle_Registro_Inicial_PrioridadMap()
        {
            this.ToTable("Detalle_Registro_Inicial_Prioridad");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
