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
        public string Participant { get; set; }
        public int Groups { get; set; }
        public int GroupSize { get; set; }
        public ICollection<Player> Players { get; set; }

    }
}
