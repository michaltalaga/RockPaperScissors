using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = SetupDI();

            var playersFactory = container.Resolve<PlayerFactory>();
            var match = container.Resolve<IMatch>();
            var player1 = playersFactory.CreatePlayer("Only Human!", PlayerType.Human);
            var player2 = playersFactory.CreatePlayer("SkyNet", PlayerType.Tactical);
            match.RoundPlayed += Match_RoundPlayed;
            var results = match.Play(3, player1, player2);


            ShowMatchResults(results);
        }

        private static void Match_RoundPlayed(object sender, RoundEventArgs e)
        {
            ShowRound(e.Round);
        }
        

        private static UnityContainer SetupDI()
        {
            var container = new UnityContainer();
            container.RegisterType<IRules, ClassicRules>();
            container.RegisterType<IRandom, Random>();
            container.RegisterInstance<IUserInput>(new ConsoleWrapper());
            container.RegisterType<IMoveStrategy, HumanMoveStrategy>(PlayerType.Human.ToString());
            container.RegisterType<IMoveStrategy, RandomMoveStrategy>(PlayerType.Random.ToString());
            container.RegisterType<IMoveStrategy, TacticalMoveStrategy>(PlayerType.Tactical.ToString());
            container.RegisterType<IPlayer, Player>();
            container.RegisterType<PlayerFactory>();
            container.RegisterType<IMatch, Match>();
            return container;
        }
        private static void ShowMatchResults(MatchResults results)
        {
            var rounds = results.Rounds.Count();
            var player1Wins = results.Rounds.Count(r => r.Player1Score > 0);
            var player1Loses = results.Rounds.Count(r => r.Player1Score < 0);
            var player1Draws = rounds - player1Wins - player1Loses;
            


            Console.WriteLine($"Player1: {player1Wins}/{player1Draws}/{player1Loses}");
            Console.WriteLine($"Player2: {player1Loses}/{player1Draws}/{player1Wins}");
        }
        private static void ShowRound(MatchResults.Round round)
        {
            Console.WriteLine($"{round.Number} \t Player1: {round.Player1Move.ToString().PadRight(8, ' ')} ( {round.Player1Score.ToString().PadLeft(2, ' ')} ) \t Player2: {round.Player2Move.ToString().PadRight(8, ' ')} ( {round.Player2Score.ToString().PadLeft(2, ' ')} )");

        }


    }


}
