using System;

namespace Chessinator.Application.Dtos
{
    public class TournamentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Seeding { get; set; }
        public string Time { get; set; }
        public DateTime Datetime { get; set; }
    }
}
