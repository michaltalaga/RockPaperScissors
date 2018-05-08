using System;

namespace RockPaperScissors
{
    public interface IMatch
    {
        MatchResults Play(int rounds, IPlayer player1, IPlayer player2);
        event EventHandler<RoundEventArgs> RoundPlayed;
    }


}
