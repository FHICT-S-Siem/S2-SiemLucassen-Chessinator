using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Application.Interfaces
{
    public interface ISaltGenerator
    {
        /// <summary>
        /// Generates a byte array to be used as salt.
        /// </summary>
        /// <returns>Returns a byte array to be used as salt.</returns>
        public byte[] GenerateSalt();
    }
}
