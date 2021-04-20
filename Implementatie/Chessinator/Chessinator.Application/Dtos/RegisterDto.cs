using System;

namespace Chessinator.Application.Dtos
{
    public class RegisterDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
    }
}
