using Artemis;
using Artemis.Manager;
using Artemis.System;
using System.Collections.Generic;

namespace RockPaperScissorsEntitySystem.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 100)]
    public class MatchControlSystem : EntitySystem
    {
        public MatchControlSystem() : base(Aspect.All())
        {

        }

        public int MaxRounds { get; set; }
        public int CurrentRound { get; private set; }
        public bool IsFinished
        {
            get
            {
                return CurrentRound == MaxRounds;
            }
        }
        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            CurrentRound++;
        }
    }

}
