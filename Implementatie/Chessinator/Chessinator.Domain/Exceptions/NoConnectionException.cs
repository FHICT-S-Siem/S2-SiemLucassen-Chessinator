using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Domain.Exceptions
{
    public class NoConnectionException : Exception
    {
        public NoConnectionException(string message) : base(message)
        {
            
        }
    }
}
