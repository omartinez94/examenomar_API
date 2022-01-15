using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Registro_Inicial_Beneficios
{
    public partial class Detalle_Registro_Inicial_BeneficiosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios>
    {
        public Detalle_Registro_Inicial_BeneficiosMap()
        {
            this.ToTable("Detalle_Registro_Inicial_Beneficios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
