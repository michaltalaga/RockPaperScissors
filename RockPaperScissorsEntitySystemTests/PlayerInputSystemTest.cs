using System;
using Artemis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Systems;
using RockPaperScissorsEntitySystem.Utils;

namespace RockPaperScissorsEntitySystemTests
{
    [TestClass]
    public class PlayerInputSystemTest
    {
        EntityWorld world;
        PlayerInputSystem system;
        Mock<IConsole> consoleMock;
        Entity humanEntity;
        [TestInitialize]
        public void Initialize()
        {
            world = new EntityWorld();
            system = new PlayerInputSystem();
            consoleMock = new Mock<IConsole>();
            consoleMock.Setup(m => m.ReadChar()).Returns('1');
            consoleMock.Setup(m => m.WindowHeight).Returns(25);
            consoleMock.Setup(m => m.WindowWidth).Returns(80);
            system.Console = consoleMock.Object;
            world.SystemManager.SetSystem(system, Artemis.Manager.GameLoopType.Update);
            humanEntity = world.CreateEntity();
            humanEntity.AddComponent(new Human());

        }
        [TestMethod]
        public void ShouldAskForUserInputOnEachIteration()
        {
            world.Update();
            consoleMock.Verify(m => m.ReadChar());
        }
        [TestMethod]
        public void ShouldShowPrompt()
        {
            world.Update();
            consoleMock.Verify(m => m.WriteAt(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));
        }
        [TestMethod]
        public void AddsMoveComponentBasedOnUserInput()
        {
            var move = humanEntity.GetComponent<Move>();
            Assert.IsNull(move);
            world.Update();
            move = humanEntity.GetComponent<Move>();
            Assert.IsNotNull(move);
            Assert.AreEqual(MoveType.Rock, move.MoveType);
        }
    }
}
