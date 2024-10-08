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
                email = value;
                Match a = Regex.Match(email, @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");
                if (a.Success == false)
                {
                    throw new EmailNoValidoException($"Email: {Email} no valido");
                }
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
