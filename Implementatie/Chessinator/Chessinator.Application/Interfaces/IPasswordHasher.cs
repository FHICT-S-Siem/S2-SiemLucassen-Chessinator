using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Application.Interfaces
{
    public interface IPasswordHasher
    {
            /// <summary>
            /// Verifies a secret with a stored salt against a stored hash.
            /// </summary>
            /// <param name="storedHash">The stored hash.</param>
            /// <param name="storedSalt">The stored salt.</param>
            /// <param name="secret">The secret.</param>
            /// <returns>Returns <c>true</c> if the hash is equal; otherwise, <c>false</c>.</returns>
            bool VerifyHash(string storedHash, string storedSalt, string secret);

            /// <summary>
            /// Hashes the secret with the salt bytes.
            /// </summary>
            /// <param name="secret">The secret.</param>
            /// <param name="saltBytes">The salt bytes.</param>
            /// <returns>Returns a hashed secret with added salt.</returns>
            string Hash(string secret, byte[] saltBytes);
        }
}
