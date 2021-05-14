using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chessinator.Application.Dtos;

namespace Chessinator.Presentation.States
{
    public class TournamentState
    {
        public TournamentDto TournamentDto { get; set; }

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
