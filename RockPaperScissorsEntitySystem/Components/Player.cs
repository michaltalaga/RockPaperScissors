using Artemis.Interface;

namespace RockPaperScissorsEntitySystem.Components
{
    public class Player : IComponent
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }


}
