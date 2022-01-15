using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Estatus_de_Usuario;
using Spartane.Core.Classes.Pais;
using Spartane.Core.Classes.Estado;
using Spartane.Core.Classes.Municipio;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Medida_de_tiempo;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Respuesta;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes._Registro_de_Usuarios
{
    /// <summary>
    /// _Registro_de_Usuarios table
    /// </summary>
    public class _Registro_de_Usuarios: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
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
        public int? Estatus { get; set; }
        public int? Pais { get; set; }
        public int? Estado { get; set; }
        public int? Municipio { get; set; }
        public string Calle { get; set; }
        public string Entre_Calle { get; set; }
        public string Y_Calle { get; set; }
        public int? Codigo_Postal { get; set; }
        public string Referencias { get; set; }
        public int? Fotografia_del_domicilio { get; set; }
        public string Fotografia_del_domicilio_URL { get; set; }
        public bool? Domicilio_actual { get; set; }
        public int? Cantidad { get; set; }
        public int? Medida_de_tiempo { get; set; }
        public string Tiempo_viviendo_aqui { get; set; }
        public DateTime? Fecha_de_autorizacion { get; set; }
        public string Hora_de_autorizacion { get; set; }
        public int? Usuario_que_autoriza { get; set; }
        public int? Respuesta { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Usuario_que_Registra")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_Registra_Spartan_User { get; set; }
        [ForeignKey("Usuario_ID")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_ID_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario Estatus_Estatus_de_Usuario { get; set; }
        [ForeignKey("Pais")]
        public virtual Spartane.Core.Classes.Pais.Pais Pais_Pais { get; set; }
        [ForeignKey("Estado")]
        public virtual Spartane.Core.Classes.Estado.Estado Estado_Estado { get; set; }
        [ForeignKey("Municipio")]
        public virtual Spartane.Core.Classes.Municipio.Municipio Municipio_Municipio { get; set; }
        [ForeignKey("Fotografia_del_domicilio")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Fotografia_del_domicilio_Spartane_File { get; set; }
        [ForeignKey("Medida_de_tiempo")]
        public virtual Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo Medida_de_tiempo_Medida_de_tiempo { get; set; }
        [ForeignKey("Usuario_que_autoriza")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_autoriza_Spartan_User { get; set; }
        [ForeignKey("Respuesta")]
        public virtual Spartane.Core.Classes.Respuesta.Respuesta Respuesta_Respuesta { get; set; }

    }
}

