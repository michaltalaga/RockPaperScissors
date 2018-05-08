using System;
using System.Collections.Generic;
using System.Threading;

namespace RockPaperScissors
{
    public class Match : IMatch
    {
        private readonly IRules rules;
        public event EventHandler<RoundEventArgs> RoundPlayed;

        public Match(IRules rules)
        {
            this.rules = rules;
        }

        public MatchResults Play(int numberOfRounds, IPlayer player1, IPlayer player2)
        {
            var rounds = new List<MatchResults.Round>();
            for (int roundNumber = 1; roundNumber <= numberOfRounds; roundNumber++)
            {
                var player1Move = player1.Move();
                var player2Move = player2.Move();
                var score = rules.GetScore(player1Move, player2Move);
                var round = new MatchResults.Round()
                {
                    Number = roundNumber,
                    Player1Move = player1Move,
                    Player2Move = player2Move,
                    Player1Score = score,
                    Player2Score = -1 * score,
                };
                rounds.Add(round);
                RoundPlayed?.Invoke(this, new RoundEventArgs(round));
            }
            return new MatchResults()
            {
                Rounds = rounds.AsReadOnly()
            };
        }
    }


}
