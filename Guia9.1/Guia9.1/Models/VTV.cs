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
        public TipoAprobacion Aprobacion 
        { 
            get
            {
                TipoAprobacion r = TipoAprobacion.Parcial;
                for (int i = 0; i < CantidadEvaluaciones; i++)
                {
                    if (evaluaciones[i].Evaluar() == TipoAprobacion.Aprobado)
                    {
                        r = TipoAprobacion.Aprobado;
                        FechaVencimiento = Fecha.AddYears(1);
                    }
                    else if (evaluaciones[i].Evaluar() == TipoAprobacion.Parcial)
                    {
                        r = TipoAprobacion.Parcial;
                        FechaVencimiento = Fecha.AddDays(20);
                    }
                    else
                    {
                        r = TipoAprobacion.NoAprobado;
                    }
                }
                return r;
            }
               
        }
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

            r[CantidadEvaluaciones + 2] = $"Resultado: {Aprobacion} - Vencimiento: {FechaVencimiento}";

            return r;
        }
        public override string ToString()
        {
            return $"{Patente} | {Aprobacion,15} | {Propietario.Dni,15} | {Fecha} | {FechaVencimiento} ";
        }
        public int CompareTo(object obj)
        {
            if (obj is Propietario && obj != null)
            {
                return Propietario.Dni.CompareTo(((Propietario)obj).Dni);
            }
            return 0;
        }
    }
}

