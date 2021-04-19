using System.Reflection.Metadata;

namespace Chessinator.Application.Dtos
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Secret { get; set; }
    }
}
