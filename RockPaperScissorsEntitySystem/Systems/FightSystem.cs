using Artemis;
using Artemis.Manager;
using Artemis.System;
using RockPaperScissorsEntitySystem.Components;
using System.Collections.Generic;
using System.Linq;
using Unity.Attributes;

namespace RockPaperScissorsEntitySystem.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 99)]
    public class FightSystem : EntitySystem
    {
        [Dependency]
        public IRules Rules { get; set; }
        public FightSystem() : base(Aspect.All(typeof(Move), typeof(Player)))
        {

        }
        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            foreach (var entity in entities.Values)
            {
                var move = entity.GetComponent<Move>();
                var player = entity.GetComponent<Player>();
                var otherEntities = entities.Values.Where(e => e != entity);
                foreach (var otherEntity in otherEntities)
                {
                    var otherMove = otherEntity.GetComponent<Move>();
                    var score = Rules.GetScore(move.MoveType, otherMove.MoveType);
                    if (score > 0) player.Score++;
                }
            }
        }
    }


}
