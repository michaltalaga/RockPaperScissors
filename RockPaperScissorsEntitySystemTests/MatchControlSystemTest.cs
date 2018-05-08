using System;
using Artemis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Systems;

namespace RockPaperScissorsEntitySystemTests
{
    [TestClass]
    public class MatchControlSystemTest
    {
        EntityWorld world;
        MatchControlSystem system;
        [TestInitialize]
        public void Initialize()
        {
            world = new EntityWorld();
            system = new MatchControlSystem();
            system.MaxRounds = 3;
            world.SystemManager.SetSystem(system, Artemis.Manager.GameLoopType.Update);
        }
        [TestMethod]
        public void EachIterationIncreasesCurrentRound()
        {
            Assert.AreEqual(0, system.CurrentRound);
            world.Update();
            Assert.AreEqual(1, system.CurrentRound);
            world.Update();
            Assert.AreEqual(2, system.CurrentRound);
        }
        [TestMethod]
        public void IsFinishedIsFinishedWhenAllRoundsArePlayed()
        {
            system.MaxRounds = 3;
            Assert.IsFalse(system.IsFinished);
            world.Update();
            Assert.IsFalse(system.IsFinished);
            world.Update();
            Assert.IsFalse(system.IsFinished);
            world.Update();
            Assert.IsTrue(system.IsFinished);
        }
    }
}
