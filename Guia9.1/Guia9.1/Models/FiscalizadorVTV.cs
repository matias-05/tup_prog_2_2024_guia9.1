using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class FiscalizadorVTV
    {
        public List<VTV> vtvs = new List<VTV>();
        public int CantidadVTV
        {
            get { return vtvs.Count; }
        }
        public VTV this[int idx]
        {
            get
            {
                if (idx >= 0 && idx <= CantidadVTV)
                {
                    return vtvs[idx];
                }
                else
                {
                    return null;
                }
            }
        }
        public VTV AgregarVTV(string patente, Propietario propietario, DateTime fecha)
        {
            VTV n = new VTV(patente, propietario, fecha);
            vtvs.Add(n);
            return n;
        }
        public List<VTV> VerVTVPorPatente(string patente)
        {
            List<VTV> ret = new List<VTV>();
            foreach (VTV v in vtvs)
            {
                if (v.Patente == patente)
                {
                    ret.Add(v);
                }
            }
            return ret;
        }
        public void OrdenarVTVsPorPropietario()
        {
            vtvs.Sort();
        }
    }
}
