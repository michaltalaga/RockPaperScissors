using Artemis;
using Artemis.Interface;
using RockPaperScissorsEntitySystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsEntitySystem.Utils
{
    public class PlayerFactory
    {
        EntityWorld world;
        public PlayerFactory(EntityWorld world)
        {
            this.world = world;
        }
        public Entity CreatePlayer<T>(string name) where T : IPlayerType, IComponent, new()
        {
            var entity = world.CreateEntity();
            entity.AddComponent(new Player(name));
            entity.AddComponent(new T());
            return entity;
        }
    }
}
