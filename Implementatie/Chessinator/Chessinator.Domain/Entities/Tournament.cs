using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Chessinator.Domain.Entities
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Seeding { get; set; }
        public string Time { get; set; }
        public DateTime DateTime { get; set; }


        public ICollection<Match> Matches { get; set; } = new List<Match>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
