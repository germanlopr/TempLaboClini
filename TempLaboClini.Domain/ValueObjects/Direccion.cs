using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempLaboClini.Domain.ValueObjects
{
    public class Direccion
    {
        public string DireccionCompleta { get; private set; }
        public string Ciudad { get; private set; }
        public string Pais { get; private set; }
        public string Departamento { get; private set; }
        public string CodigoZonaPostal { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }

        // Constructor para asignar los valores
        public Direccion(string direccionCompleta, string ciudad, string pais, string departamento, string codigoZonaPostal, string telefono, string email)
        {
            DireccionCompleta = direccionCompleta;
            Ciudad = ciudad;
            Pais = pais;
            Departamento = departamento;
            CodigoZonaPostal = codigoZonaPostal;
            Telefono = telefono;
            Email = email;
        }

        public override string ToString()
        {
            return $"{DireccionCompleta}, {Ciudad}, {Departamento}, {Pais} - {CodigoZonaPostal}, {Telefono}, {Email}";
        }
    }

}
