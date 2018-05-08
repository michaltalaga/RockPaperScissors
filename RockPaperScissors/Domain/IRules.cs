namespace RockPaperScissors
{
    public interface IRules
    {
        int GetScore(Move move1, Move move2);
        Move GetWinningMove(Move other);
    }


}
