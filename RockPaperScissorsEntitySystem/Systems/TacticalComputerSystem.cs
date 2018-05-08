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
    public class TacticalComputerSystem : EntityProcessingSystem
    {
        [Dependency]
        public IRandom Random { get; set; }
        [Dependency]
        public IRules Rules { get; set; }
        public TacticalComputerSystem() : base(Aspect.All(typeof(TacticalComputer)))
        {

        }

        public override void Process(Entity entity)
        {
            var previousMove = entity.GetComponent<Move>();
            if (previousMove == null)
            {
                entity.AddComponent(new Move()
                {
                    MoveType = (MoveType)Random.Next(1, Enum.GetValues(typeof(MoveType)).Length),
                });
            }
            else
            {
                entity.AddComponent(new Move()
                {
                    MoveType = Rules.GetWinningMove(previousMove.MoveType),
                });
            }
        }
    }


}
