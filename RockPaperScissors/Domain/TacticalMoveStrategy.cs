namespace RockPaperScissors
{
    public class TacticalMoveStrategy : RandomMoveStrategy
    {
        private readonly IRules rules;
        private Move? lastMove;

        public TacticalMoveStrategy(IRandom random, IRules rules) : base(random)
        {
            this.rules = rules;
        }
        public override Move GetNext()
        {
            if (lastMove == null)
            {
                var move = base.GetNext();
                lastMove = move;
                return move;
            }
            else
            {
                var move = rules.GetWinningMove(lastMove.Value);
                lastMove = move;
                return move;
            }
        }
    }


}
