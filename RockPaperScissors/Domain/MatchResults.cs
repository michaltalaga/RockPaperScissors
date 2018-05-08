using System.Collections.Generic;

namespace RockPaperScissors
{
    public class MatchResults
    {
        public IEnumerable<Round> Rounds { get; set; }
        public class Round
        {
            public int Number { get; internal set; }
            public Move Player1Move { get; internal set; }
            public Move Player2Move { get; internal set; }
            public int Player1Score { get; internal set; }
            public int Player2Score { get; internal set; }
        }

    }


}
