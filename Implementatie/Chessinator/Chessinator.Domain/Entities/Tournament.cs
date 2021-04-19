using System;

namespace Chessinator.Domain.Entities
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Seeding { get; set; }
        public string Time { get; set; }
        public DateTime DateTime { get; set; }
    }
}
