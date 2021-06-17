using System;

namespace Chessinator.Domain.Exceptions
{
    public class ChessinatorException : Exception
    {
        public ChessinatorException(string message) : base(message)
        {
            
        }
    }
}
