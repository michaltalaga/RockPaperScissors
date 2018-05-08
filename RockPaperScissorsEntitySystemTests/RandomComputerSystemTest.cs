using System;
using Artemis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissorsEntitySystem;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Systems;
using RockPaperScissorsEntitySystem.Utils;

namespace RockPaperScissorsEntitySystemTests
{
    [TestClass]
    public class RandomComputerSystemTest
    {
        EntityWorld world;
        RandomComputerSystem system;
        Mock<IRandom> randomMock;
        Entity entity;
        [TestInitialize]
        public void Initialize()
        {
            world = new EntityWorld();
            system = new RandomComputerSystem();
            randomMock = new Mock<IRandom>();
            randomMock.Setup(m => m.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            system.Random = randomMock.Object;
            
            world.SystemManager.SetSystem(system, Artemis.Manager.GameLoopType.Update);
            entity = world.CreateEntity();
            entity.AddComponent(new RandomComputer());
        }
        [TestMethod]
        public void ShouldUseProvidedRandomGenerator()
        {
            world.Update();
            randomMock.Verify(m => m.Next(1, Enum.GetValues(typeof(MoveType)).Length));
        }
        [TestMethod]
        public void ShouldAddCorrectMoveComponent()
        {
            var move = entity.GetComponent<Move>();
            Assert.IsNull(move);
            world.Update();
            move = entity.GetComponent<Move>();
            Assert.IsNotNull(move);
            Assert.AreEqual(MoveType.Paper, move.MoveType);

        }
       
    }
}
