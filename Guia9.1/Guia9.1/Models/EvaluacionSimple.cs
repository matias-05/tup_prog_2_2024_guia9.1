using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class EvaluacionSimple : Evaluacion
    {
        public bool HaVerificado { get; set; } 
        public EvaluacionSimple(string nombre, string descripcion):base(nombre,descripcion) 
        {
        }
        public override TipoAprobacion Evaluar()
        {
            if (HaVerificado)
            {
                return TipoAprobacion.Aprobado;
            }
            else
            {
                return TipoAprobacion.NoAprobado;
            }
        }
    }
}
