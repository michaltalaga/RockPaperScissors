using System;

namespace RockPaperScissors
{
    public class HumanMoveStrategy : IMoveStrategy
    {
        private readonly IUserInput userInput;

        public HumanMoveStrategy(IUserInput userInput)
        {
            this.userInput = userInput;
        }

        public Move GetNext()
        {
            var key = userInput.GetUserInput();
            try
            {
                return (Move)int.Parse(key.ToString());
            }
            catch
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }


}
