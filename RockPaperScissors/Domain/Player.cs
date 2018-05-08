using System.Diagnostics;

namespace RockPaperScissors
{
    [DebuggerDisplay("{Name} ({strategy})")]
    public class Player : IPlayer
    {
        private readonly IMoveStrategy strategy;
        public string Name { get; private set; }
        public int Score { get; set; }
        public Player(string name, IMoveStrategy strategy)
        {
            Name = name;
            this.strategy = strategy;
        }

        public Move Move()
        {
            return strategy.GetNext();
        }
    }


}
