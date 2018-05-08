using Artemis.Interface;
using Artemis.System;
using Artemis.Utils;
using RockPaperScissorsEntitySystem.Systems;
using RockPaperScissorsEntitySystem.Utils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using System.Linq;
using RockPaperScissorsEntitySystem.Components;

namespace RockPaperScissorsEntitySystem
{
    class Program
    {
        static Artemis.EntityWorld world = new Artemis.EntityWorld();
        static UnityContainer container = new UnityContainer();
        static void Main(string[] args)
        {
            Initialize();
            CreatePlayers();

            var matchControlSystem = world.SystemManager.Systems.OfType<MatchControlSystem>().First();
            matchControlSystem.MaxRounds = 3;
            Task.Run(() =>
            {
                while (true)
                {
                    world.Draw();
                    Thread.Sleep(100);
                }
            });
            do
            {

                world.Update();
                Thread.Sleep(1000);
            }
            while (!matchControlSystem.IsFinished);

            var console = container.Resolve<IConsole>();
            console.WriteAt(console.WindowWidth / 2 - 2, console.WindowHeight / 2, "Done");
            console.ReadLine();

        }

        private static void Initialize()
        {
            world.InitializeAll(true);
            Inject(world.SystemManager.Systems);
        }

        private static void CreatePlayers()
        {
            var playerFactory = new PlayerFactory(world);
            playerFactory.CreatePlayer<RandomComputer>("machine 1");
            playerFactory.CreatePlayer<RandomComputer>("machine 2");
            playerFactory.CreatePlayer<RandomComputer>("machine 3");
            playerFactory.CreatePlayer<RandomComputer>("machine 4");
            playerFactory.CreatePlayer<TacticalComputer>("skynet");
            playerFactory.CreatePlayer<Human>("only human");
        }

        private static void Inject(IEnumerable<EntitySystem> systems)
        {

            container.RegisterType<IRandom, Utils.Random>();
            container.RegisterType<IRules, ExtendedRules>();
            container.RegisterInstance<IConsole>(new ConsoleWrapper());
            foreach (var system in systems)
            {
                container.BuildUp(system.GetType(), system);
            }
        }


    }

}
