﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Secret { get; set; }
        public string Extra { get; set; }
        public string Role { get; set; }
        public string UserStatus { get; set; }
        public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
    }
}
