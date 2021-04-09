using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Chessinator.Application.Interfaces;

namespace Chessinator.Application.Cryptography
{
    public class SaltGenerator
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
}
