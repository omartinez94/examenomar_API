using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_Selall_Registro_de_Usuarios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Confirmar_Contrasena { get; set; }
        public string Correo_Electronico { get; set; }
        public string Celular { get; set; }
        public int? Usuario_ID { get; set; }
        public string Usuario_ID_Name { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int? Pais { get; set; }
        public string Pais_Nombre { get; set; }
        public int? Estado { get; set; }
        public string Estado_Nombre { get; set; }
        public int? Municipio { get; set; }
        public string Municipio_Nombre { get; set; }
        public string Calle { get; set; }
        public string Entre_Calle { get; set; }
        public string Y_Calle { get; set; }
        public int? Codigo_Postal { get; set; }
        public string Referencias { get; set; }
        public int? Fotografia_del_domicilio { get; set; }
        public bool? Domicilio_actual { get; set; }
        public int? Cantidad { get; set; }
        public int? Medida_de_tiempo { get; set; }
        public string Medida_de_tiempo_Descripcion { get; set; }
        public string Tiempo_viviendo_aqui { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public string Usuario_que_autoriza_Name { get; set; }
        public int? Respuesta { get; set; }
        public string Respuesta_Descripcion { get; set; }
        public string Observaciones { get; set; }

    }
}
