using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Domain.Exceptions
{
    public class InvalidTournamentException : Exception
    {
        public InvalidTournamentException(string message) : base(message)
        {
            
        }
    }
}
