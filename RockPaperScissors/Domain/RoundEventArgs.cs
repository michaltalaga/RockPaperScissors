using System;

namespace RockPaperScissors
{
    public class RoundEventArgs : EventArgs
    {
        public RoundEventArgs(MatchResults.Round round)
        {
            Round = round;
        }

        public MatchResults.Round Round { get; }
    }


}
