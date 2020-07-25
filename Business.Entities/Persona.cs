using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona:BusinessEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IDPLan { get; set; }
        public int Legajo { get; set; }
        public string Telefono { get; set; }
        public TiposPersonas TipoPersona { get; set; }

        public enum TiposPersonas
        {
            Tipo1,
            Tipo2,
            Tipo3,
            Tipo4
        }
    }
}
