using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class PatenteNoValidaException : ApplicationException
    {
        public PatenteNoValidaException() { }
        public PatenteNoValidaException(string message) : base(message) { }
        public PatenteNoValidaException(string message, Exception innerException) : base(message, innerException) { }

    }
}
