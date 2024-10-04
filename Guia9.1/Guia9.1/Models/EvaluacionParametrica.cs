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
            double v70 = ValorMinimo * (1 - ValorTolerado / 100);
            double v130 = ValorMaximo * (1 + ValorTolerado / 100);
            if (ValorMedido < v70)
            {
                return TipoAprobacion.NoAprobado;
            }
            else if (ValorMedido < ValorMinimo)
            {
                return TipoAprobacion.Parcial;
            }
            else if(ValorMedido <= ValorMaximo)
            {
                return TipoAprobacion.Aprobado;
            } 
            else if (ValorMedido < v130)
            {
                return TipoAprobacion.Parcial;
            }
            else
            {
                return TipoAprobacion.Aprobado;
            }
        }
    }
}
