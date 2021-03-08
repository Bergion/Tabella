using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabinet.API.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class CabinetDomainException : Exception
    {
        public CabinetDomainException()
        { 
        }

        public CabinetDomainException(string message)
            : base(message)
        {
        }

        public CabinetDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
