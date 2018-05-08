using Artemis.Interface;

namespace RockPaperScissorsEntitySystem.Components
{
    public class Move : IComponent
    {
        public MoveType MoveType { get; set; }
    }


}
