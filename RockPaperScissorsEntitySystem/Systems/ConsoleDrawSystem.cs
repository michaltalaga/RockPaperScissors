using Artemis;
using Artemis.Manager;
using Artemis.System;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Attributes;

namespace RockPaperScissorsEntitySystem.Systems
{
    [Artemis.Attributes.ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, ExecutionType = ExecutionType.Synchronous)]
    public class ConsoleDrawSystem : EntitySystem
    {
        [Dependency]
        public IConsole Console { get; set; }
        const int colWidth = 20;
        public ConsoleDrawSystem() : base(Aspect.All(typeof(Player)))
        {

        }
       
        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            
                int entityNumber = 0;
                foreach (var entity in entities.Values)
                {
                    var player = entity.GetComponent<Player>();
                    var move = entity.GetComponent<Move>();
                    var playerType = entity.Components.OfType<IPlayerType>().FirstOrDefault().GetType().Name;

                    var left = entityNumber * colWidth;
                    Console.WriteAt(left, 0, player.Name);
                    Console.WriteAt(left, 1, $"({playerType})");
                    Console.WriteAt(left, 2, "Move: " + move?.MoveType.ToString().PadRight(13, ' '));
                    Console.WriteAt(left, 3, "Score: " + player.Score);
                    entityNumber++;
                }
           
           
        }
      
    }


}
