using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAll_Registro_de_Usuarios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int _Registro_de_Usuarios_Folio { get; set; }
        public DateTime? _Registro_de_Usuarios_Fecha_de_Registro { get; set; }
        public string _Registro_de_Usuarios_Hora_de_Registro { get; set; }
        public int? _Registro_de_Usuarios_Usuario_que_Registra { get; set; }
        public string _Registro_de_Usuarios_Usuario_que_Registra_Name { get; set; }
        public string _Registro_de_Usuarios_Nombres { get; set; }
        public string _Registro_de_Usuarios_Apellido_Paterno { get; set; }
        public string _Registro_de_Usuarios_Apellido_Materno { get; set; }
        public string _Registro_de_Usuarios_Nombre_Completo { get; set; }
        public string _Registro_de_Usuarios_Usuario { get; set; }
        public string _Registro_de_Usuarios_Contrasena { get; set; }
        public string _Registro_de_Usuarios_Confirmar_Contrasena { get; set; }
        public string _Registro_de_Usuarios_Correo_Electronico { get; set; }
        public string _Registro_de_Usuarios_Celular { get; set; }
        public int? _Registro_de_Usuarios_Usuario_ID { get; set; }
        public string _Registro_de_Usuarios_Usuario_ID_Name { get; set; }
        public int? _Registro_de_Usuarios_Estatus { get; set; }
        public string _Registro_de_Usuarios_Estatus_Descripcion { get; set; }
        public int? _Registro_de_Usuarios_Pais { get; set; }
        public string _Registro_de_Usuarios_Pais_Nombre { get; set; }
        public int? _Registro_de_Usuarios_Estado { get; set; }
        public string _Registro_de_Usuarios_Estado_Nombre { get; set; }
        public int? _Registro_de_Usuarios_Municipio { get; set; }
        public string _Registro_de_Usuarios_Municipio_Nombre { get; set; }
        public string _Registro_de_Usuarios_Calle { get; set; }
        public string _Registro_de_Usuarios_Entre_Calle { get; set; }
        public string _Registro_de_Usuarios_Y_Calle { get; set; }
        public int? _Registro_de_Usuarios_Codigo_Postal { get; set; }
        public string _Registro_de_Usuarios_Referencias { get; set; }
        public int? _Registro_de_Usuarios_Fotografia_del_domicilio { get; set; }
        public string _Registro_de_Usuarios_Fotografia_del_domicilio_Nombre { get; set; }
        public bool? _Registro_de_Usuarios_Domicilio_actual { get; set; }
        public int? _Registro_de_Usuarios_Cantidad { get; set; }
        public int? _Registro_de_Usuarios_Medida_de_tiempo { get; set; }
        public string _Registro_de_Usuarios_Medida_de_tiempo_Descripcion { get; set; }
        public string _Registro_de_Usuarios_Tiempo_viviendo_aqui { get; set; }
        public DateTime? _Registro_de_Usuarios_Fecha_de_autorizacion { get; set; }
        public string _Registro_de_Usuarios_Hora_de_autorizacion { get; set; }
        public int? _Registro_de_Usuarios_Usuario_que_autoriza { get; set; }
        public string _Registro_de_Usuarios_Usuario_que_autoriza_Name { get; set; }
        public int? _Registro_de_Usuarios_Respuesta { get; set; }
        public string _Registro_de_Usuarios_Respuesta_Descripcion { get; set; }
        public string _Registro_de_Usuarios_Observaciones { get; set; }

    }
}
