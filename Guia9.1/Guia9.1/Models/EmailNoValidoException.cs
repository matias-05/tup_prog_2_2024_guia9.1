using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guia9._1.Models
{
    internal class EmailNoValidoException : ApplicationException
    {
        public EmailNoValidoException() { }
        public EmailNoValidoException(string message) : base(message) { }
        public EmailNoValidoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
