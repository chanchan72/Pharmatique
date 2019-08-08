using System;
using System.ComponentModel.DataAnnotations;


namespace MVC.Librerias.EntidadesNegocio
{
    public class beLogin
    {
        [Required(ErrorMessage = "El campo Usuario es obligatorio.")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }        
        public string Aplicacion { get; set; }
        public virtual beRestablecer beRestablecer { get; set; }
    }
}
