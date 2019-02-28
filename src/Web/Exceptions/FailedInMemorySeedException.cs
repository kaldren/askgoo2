using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskGoo2.Web.Exceptions
{
    public class FailedInMemorySeedException : Exception
    {
        public FailedInMemorySeedException()
        {
        }

        public FailedInMemorySeedException(string message) : base(message)
        {
        }

        public FailedInMemorySeedException(string message, Exception inner)
        {
        }
    }
}
