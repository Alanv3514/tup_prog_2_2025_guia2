using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Modelos
{
    public class Servicio
    {
        private List<Persona> Personas = new List<Persona>();

        public Servicio() {}
        public bool AgregarPersona(Persona nuevaPersona) 
        {

            if (Personas.Contains(nuevaPersona))
                return false;

            Personas.Add(nuevaPersona);

            return true;
        }
        public int CantidadPersonas() 
        {
            return Personas.Count();
        }
        public Persona VerPersona(int indice) 
        {

            if (indice >= 0 && indice < Personas.Count())
            {
                return Personas[indice];
            }
            return null;
        }


        public Persona VerPersonaPorDni(int dni)
        {   
            for (int i = 0; i < Personas.Count(); i++)
            {
                if (Personas[i].Dni == dni)
                    return Personas[i];
            }
            return null;
        }

        public void EliminarPersona(Persona persona)
        {
            Personas.Remove(persona);
        }


        public bool ModificarPersona(int id,Persona nuevaPersona)
        {
            Personas[id] = nuevaPersona;

            return true;
        }


    }
}
