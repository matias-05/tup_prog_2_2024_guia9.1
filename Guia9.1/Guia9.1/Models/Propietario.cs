using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class Propietario
    {
        int dni;
        public int Dni 
        { 
            get
            {
                return dni;
            }
            set
            {
                if (value < 1000000)
                {
                    throw new DniNoValidoException($"Dni: {Dni} no valido");
                }
                dni = value;
            }
        }

        public string ApellidosNombres { get; set; }
        string email;
        public string Email 
        {
            get 
            {
                return email;
            }
            set 
            {
                if (Regex.Match(email, "@^[w]{3} [w]{*} [w]{3} [@]{1} [w]{3} [w]{*} [w]{3} [.com]{4} [.]{1} [w]{2} $").Success == false)
                {
                    throw new EmailNoValidoException($"Email: {Email} no valido");
                }
                email = value;
            }
        }
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
