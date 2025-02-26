using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLaboClini.Domain.Entities
{
    public class Usuario : Persona
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string TipoUsuario { get; set; }
        public string Estado { get; set; }
    }
}
