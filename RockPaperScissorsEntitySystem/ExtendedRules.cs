using RockPaperScissorsEntitySystem.Components;
using System;

namespace RockPaperScissorsEntitySystem
{
    public class ExtendedRules : IRules
    {
        public int GetScore(MoveType move1, MoveType move2)
        {
            if (move1 == move2) return 0;
            switch (move1)
            {
                case MoveType.Rock: return (move2 == MoveType.Scissors || move2 == MoveType.Lizard) ? 1 : -1;
                case MoveType.Paper: return (move2 == MoveType.Rock || move2 == MoveType.Spock) ? 1 : -1;
                case MoveType.Scissors: return (move2 == MoveType.Paper || move2 == MoveType.Lizard) ? 1 : -1;
                case MoveType.Lizard: return (move2 == MoveType.Paper || move2 == MoveType.Spock) ? 1 : -1;
                case MoveType.Spock: return (move2 == MoveType.Scissors || move2 == MoveType.Rock) ? 1 : -1;
                default: throw new NotSupportedException($"Crazy moves!");
            }
        }
        public MoveType GetWinningMove(MoveType other)
        {
            foreach (MoveType move in Enum.GetValues(typeof(MoveType)))
            {
                if (GetScore(move, other) > 0)
                {
                    return move;
                }
            }
            throw new InvalidOperationException("Unknown move");
        }
    }


}
