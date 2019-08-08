using System;
using System.Collections.Generic;

namespace General.Librerias.Entidades.GestionUsuarios
{
    public class beDatosUsuariosGestion
    {
        public List<beUsuarioGestion> ListaUsuarios { get; set; }
        public List<beRolGestion> ListaRoles { get; set; }
        public List<beUsuariosRolesGestion> ListaUsuariosRoles { get; set; }
    }
}
