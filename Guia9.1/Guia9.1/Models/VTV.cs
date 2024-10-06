using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class VTV : IComparable
    {
        //Evaluacion a = new EvaluacionParametrica("Prueba de frenos delanteros", "Porcentaje de diferencia de frenado entre ejes", 0, 30, "Porcentaje", double tolerado);
        public Propietario Propietario { get; private set; }
        List<Evaluacion> evaluaciones = new List<Evaluacion>();
        public string Patente { get; private set; }
        public DateTime Fecha { get; private set; }
        public DateTime FechaVencimiento 
        {
            get
            {
                if (Aprobacion == TipoAprobacion.Aprobado)
                {
                    return Fecha.AddYears(1);
                }
                else if (Aprobacion == TipoAprobacion.Parcial)
                {
                    return Fecha.AddDays(20);
                }
                else
                {
                    return Fecha;
                }
            }
        }
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
                    }
                    else if (evaluaciones[i].Evaluar() == TipoAprobacion.Parcial)
                    {
                        r = TipoAprobacion.Parcial;
                    }
                    else
                    {
                        r = TipoAprobacion.NoAprobado;
                    }
                }
                return r;
            }
               
        }
        public VTV(string patente, Propietario propietario, DateTime fecha)
        {
            if (Regex.Match(patente, @" ^[A-Z]{2} [0-9]{3} [A-Z]{2}$ | ^ [A-Z]{3} [0-9]{3}$ ", RegexOptions.IgnoreCase).Success == false)
            {
                throw new PatenteNoValidaException($"Patente: {patente} no valida");
            }
            Patente = patente;
            Propietario = propietario;
            Fecha = fecha;
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

