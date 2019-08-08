using System;
using System.ComponentModel.DataAnnotations;


namespace MVC.Librerias.EntidadesNegocio
{
    public class beCambioClave
    {
        public string LOGIN_NAME { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Nueva contraseña")]
        public string ConfirmarPassword { get; set; }
    }
}
