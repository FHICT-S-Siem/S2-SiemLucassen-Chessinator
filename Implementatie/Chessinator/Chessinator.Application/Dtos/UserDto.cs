using System;
using System.Collections.Generic;
using Chessinator.Domain.Entities;

namespace Chessinator.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public string UserStatus { get; set; }
        public List<TournamentDto> Tournaments { get; set; }
    }
}
