using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class EvaluacionParametrica : Evaluacion
    {
        public double ValorMinimo { get; private set; }
        public double ValorMaximo { get; private set; }
        public double ValorTolerado { get; private set; }
        public double ValorMedido { get; set; }
        public string Unidad { get; private set; }
        public EvaluacionParametrica(string nombre, string descripcion, double minimo, double maximo, string unidad, double tolerado):base(nombre,descripcion)
        {
            ValorMinimo = minimo;
            ValorMaximo = maximo;
            ValorTolerado = tolerado;
            Unidad = unidad;
        }
        public override TipoAprobacion Evaluar()
        {
            if (ValorMedido >= 30)
            {
                return TipoAprobacion.Aprobado;
            }
            else if (ValorMedido >= 21)
            {
                return TipoAprobacion.Parcial;
            }
            else 
            {
                return TipoAprobacion.NoAprobado;
            }
        }
    }
}
