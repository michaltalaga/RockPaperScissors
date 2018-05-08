using System;

namespace RockPaperScissors
{
    public class ClassicRules : IRules
    {
        public int GetScore(Move move1, Move move2)
        {
            if (move1 == move2) return 0;
            switch (move1)
            {
                case Move.Rock: return move2 == Move.Scissors ? 1 : -1;
                case Move.Paper: return move2 == Move.Rock ? 1 : -1;
                case Move.Scissors: return move2 == Move.Paper ? 1 : -1;
                default: throw new NotSupportedException($"Crazy moves!");
            }
        }
        public Move GetWinningMove(Move other)
        {
            foreach (Move move in Enum.GetValues(typeof(Move)))
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
