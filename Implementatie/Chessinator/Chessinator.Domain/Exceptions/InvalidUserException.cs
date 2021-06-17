using System;

namespace Chessinator.Domain.Exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message) : base(message)
        {

        }
    }
}
;