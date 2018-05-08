using Artemis;
using Artemis.Manager;
using Artemis.System;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Utils;
using System;
using System.Linq;
using Unity.Attributes;

namespace RockPaperScissorsEntitySystem.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(GameLoopType = GameLoopType.Update)]
    public class PlayerInputSystem : EntityProcessingSystem
    {
        [Dependency]
        public IConsole Console { get; set; }
        public PlayerInputSystem() : base(Aspect.All(typeof(Human)))
        {

        }
        public override void Process(Entity entity)
        {
            Console.WriteAt(0, Console.WindowHeight - 1, "Choose your next move: " + string.Join(", ", ((int[])Enum.GetValues(typeof(MoveType))).Select(v => v + " - " + Enum.GetName(typeof(MoveType), v))));
            var c = Console.ReadChar();
            var choice = int.Parse(c.ToString());
            entity.AddComponent(new Move()
            {
                MoveType = (MoveType)choice
            });
            Console.WriteAt(0, Console.WindowHeight - 1, "".PadRight(Console.WindowWidth - 1, ' '));
        }
    }


}
