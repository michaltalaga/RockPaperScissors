using System;
using System.Linq;

namespace RockPaperScissors
{
    public class RandomMoveStrategy : IMoveStrategy
    {
        private readonly IRandom random;

        public RandomMoveStrategy(IRandom random)
        {
            this.random = random;
        }

        public virtual Move GetNext()
        {
            var values = (int[])Enum.GetValues(typeof(Move));
            return (Move)random.Next(values.Min(), values.Max());
        }
    }


}
