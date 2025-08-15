using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Modelos
{
    public class Persona
    {
        public int Dni { get; }
        public string Nombre { get; set; }

        public Persona(int dni, string nombre)
        {
            this.Dni = dni;
            this.Nombre = nombre;
        }

        public string Describir() 
        {
            return $@"{{
    ""DNI"":{this.Dni},
    ""Nombre"":{this.Nombre}
}}
";
        }

        public string DescribirEnLinea()
        {
            return  $"{this.Dni} - {this.Nombre}";
        }
    }
}
