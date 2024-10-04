using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class Propietario
    {
        public int Dni { get; set; }
        public string ApellidosNombres { get; set; }
        public string Email { get; set; }
        public Propietario(int dni, string nombre, string email) 
        {
            Dni = dni;
            Email = email;
            ApellidosNombres = nombre;
        }
        public override string ToString()
        {
            return $"Dni: {Dni} \r\nNombre completo: {ApellidosNombres} \r\nEmail: {Email}";
        }
    }
}
