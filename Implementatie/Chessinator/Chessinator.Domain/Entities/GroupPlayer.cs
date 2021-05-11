using System;
using System.Collections.Generic;
using System.Text;

namespace Chessinator.Domain.Entities
{
    public class GroupPlayer
    {
        public Guid PlayerId { get; set; }
        public Guid GroupId { get; set; }
        public Player Player { get; set; }
        public Group Group { get; set; }
    }
}
