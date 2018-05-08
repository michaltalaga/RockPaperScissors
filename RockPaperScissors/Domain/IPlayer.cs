namespace RockPaperScissors
{
    public interface IPlayer
    {
        string Name { get; }
        int Score { get; set; }
        Move Move();
    }


}
