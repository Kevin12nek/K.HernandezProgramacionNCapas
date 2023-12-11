using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public byte IdUsuario { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido Paterno es requerido")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }


        [Required(ErrorMessage = "El Apellido Materno es requerido")]
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sexo { get; set; }
        [Required]
        [MaxLength(10), MinLength(10)]
        public string Telefono { get; set; }
        public string Celular { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
        public string CURP { get; set; }
        public byte[] Imagen { get; set; }
        public ML.Rol Rol { get; set; }
        public List<object> Usuarios { get; set; }
        public List<object> Roles { get; set; }
        public ML.Direccion Direccion { get; set; }



    }
}
