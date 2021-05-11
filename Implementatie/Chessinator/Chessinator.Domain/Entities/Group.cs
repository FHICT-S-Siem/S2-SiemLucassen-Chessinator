using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public Guid TournamentId { get; set; }
        public string Name { get; set; }
        public string Participant1 { get; set; }
        public string Participant2 { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public List<GroupPlayer> GroupPlayers { get; set; } = new List<GroupPlayer>();
    }
}
