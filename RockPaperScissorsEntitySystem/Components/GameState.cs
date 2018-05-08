using Artemis.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsEntitySystem.Components
{
    public class GameState : IComponent
    {
        public int MaxRounds { get; set; }
        public int CurrentRound { get; set; }
    }
}
