using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal abstract class Evaluacion
    {
        public string Nombre { get; protected set; }
        public string Descripcion { get; protected set; }
        public Evaluacion(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        abstract public TipoAprobacion Evaluar();
        public override string ToString()
        {
            return $"Nombre: {Nombre} - Descripción: {Descripcion} - {Evaluar()}";
        }
    }
}
