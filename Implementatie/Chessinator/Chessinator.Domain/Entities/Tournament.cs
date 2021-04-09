using System;

namespace Chessinator.Domain.Entities
{
    public class Tournament
    {
        public Guid Id { get; set; }
        public string TournamentName { get; set; }
        public string TournamentType { get; set; }
        public string TournamentSeeding { get; set; }
        public string TournamentTime { get; set; }
        public DateTime TournamentDatetime { get; set; }
    }
}
