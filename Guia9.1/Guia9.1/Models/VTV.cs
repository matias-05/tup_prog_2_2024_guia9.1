using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class VTV : IComparable
    {
        public Propietario Propietario { get; private set; }
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        public string Patente { get; private set; }
        public DateTime Fecha { get; private set; }
        public DateTime FechaVencimiento { get; private set; }
        public int CantidadEvaluaciones
        {
            get
            {
                return evaluaciones.Count;
            }
        }
        public Evaluacion this[int idx]
        {
            get
            {
                if (idx >= 0 && idx <= CantidadEvaluaciones)
                {
                    return evaluaciones[idx];
                }
                else
                {
                    return null;
                }
            }
        }
        public TipoAprobacion Aprobacion { get; private set; }
        public VTV(string patente, Propietario propietario)
        {
            Patente = patente;
            Propietario = propietario;
        }
        public string[] EmitirComprobante()
        {
            string[] r = new string[CantidadEvaluaciones+2];

            r[0] = $"{Patente} {Propietario.ApellidosNombres} ({Propietario.Dni})";

            for (int i = 1; i< CantidadEvaluaciones ;i++)
            {
                r[i] = evaluaciones[i].ToString();
            }

            r[CantidadEvaluaciones + 2] = $"Vencimiento {FechaVencimiento}";

            return r;
        }
    }
}

