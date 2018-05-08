using RockPaperScissorsEntitySystem.Components;

namespace RockPaperScissorsEntitySystem
{
    public interface IRules
    {
        int GetScore(MoveType move1, MoveType move2);
        MoveType GetWinningMove(MoveType other);
    }


}
