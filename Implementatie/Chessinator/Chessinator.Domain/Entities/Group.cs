using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessinator.Domain.Entities
{
    public class Group
    {
        public string Participant { get; set; }
        public int Groups { get; set; }

        public int GroupSize { get; set; }
    }
}
