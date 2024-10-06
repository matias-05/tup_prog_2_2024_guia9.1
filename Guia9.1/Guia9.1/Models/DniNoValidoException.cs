using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class DniNoValidoException : ApplicationException
    {
        public DniNoValidoException() { }
        public DniNoValidoException(string message) : base(message) { }
        public DniNoValidoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
