using Artemis;
using Artemis.Manager;
using Artemis.System;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Utils;
using System;
using Unity.Attributes;

namespace RockPaperScissorsEntitySystem.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    public class RandomComputerSystem : EntityProcessingSystem
    {
        [Dependency]
        public IRandom Random { get; set; }
        public RandomComputerSystem() : base(Aspect.All(typeof(RandomComputer)))
        {

        }

        public override void Process(Entity entity)
        {

            entity.AddComponent(new Move()
            {
                MoveType = (MoveType)Random.Next(1, Enum.GetValues(typeof(MoveType)).Length),
            });
        }
    }


}
