using Unity;
using Unity.Resolution;

namespace RockPaperScissors
{
    public class PlayerFactory
    {
        private readonly IUnityContainer container;

        public PlayerFactory(IUnityContainer container)
        {
            this.container = container;
        }
        public IPlayer CreatePlayer(string name, PlayerType playerType)
        {
            var strategy = container.Resolve<IMoveStrategy>(playerType.ToString());
            return container.Resolve<IPlayer>(new ParameterOverride(nameof(IPlayer.Name).ToLower(), name), new DependencyOverride(typeof(IMoveStrategy), strategy));
        }

    }


}
