using Chessinator.Application.Interfaces;
using System.Security.Cryptography;

namespace Chessinator.Application.Cryptography
{
    public class RandomSaltGenerator : ISaltGenerator
    {
        public byte[] GenerateSalt()
        {
            byte[] saltAsBytes = new byte[128 / 8];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                rng.GetBytes(saltAsBytes);

            return saltAsBytes;
        }
    }
}
