using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Domain.Exceptions
{
    public class ChessinatorException : Exception
    {
        public ChessinatorException(string message) : base(message)
        {
            
        }
    }
}
