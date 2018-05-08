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
    public class TacticalComputerSystemTest
    {
        EntityWorld world;
        TacticalComputerSystem system;
        Mock<IRandom> randomMock;
        Mock<IRules> rulesMock;
        Entity entity;
        [TestInitialize]
        public void Initialize()
        {
            world = new EntityWorld();
            system = new TacticalComputerSystem();
            randomMock = new Mock<IRandom>();
            randomMock.Setup(m => m.Next(It.IsAny<int>(), It.IsAny<int>())).Returns((int)MoveType.Paper);
            system.Random = randomMock.Object;
            rulesMock = new Mock<IRules>();
            rulesMock.Setup(m => m.GetWinningMove(MoveType.Paper)).Returns(MoveType.Scissors);
            rulesMock.Setup(m => m.GetWinningMove(MoveType.Scissors)).Returns(MoveType.Rock);
            system.Rules = rulesMock.Object;
            world.SystemManager.SetSystem(system, Artemis.Manager.GameLoopType.Update);
            entity = world.CreateEntity();
            entity.AddComponent(new TacticalComputer());
        }
        [TestMethod]
        public void ShouldUseProvidedRandomGeneratorOnFirstIterationOnly()
        {
            world.Update();
            randomMock.Verify(m => m.Next(1, Enum.GetValues(typeof(MoveType)).Length));
            world.Update();
            randomMock.VerifyNoOtherCalls();
        }
        [TestMethod]
        public void ShouldUseProvidedRules()
        {
            world.Update();
            world.Update();
            rulesMock.Verify(m => m.GetWinningMove(MoveType.Paper));
            world.Update();
            rulesMock.Verify(m => m.GetWinningMove(MoveType.Scissors));
        }
        [TestMethod]
        public void ShouldAddCorrectMoveComponent()
        {
            var move = entity.GetComponent<Move>();
            Assert.IsNull(move);
            world.Update();
            world.Update();
            move = entity.GetComponent<Move>();
            Assert.IsNotNull(move);
            Assert.AreEqual(MoveType.Scissors, move.MoveType);
            world.Update();
            move = entity.GetComponent<Move>();
            Assert.AreEqual(MoveType.Rock, move.MoveType);
        }
       
    }
}
