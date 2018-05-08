using System;
using Artemis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissorsEntitySystem;
using RockPaperScissorsEntitySystem.Components;
using RockPaperScissorsEntitySystem.Systems;

namespace RockPaperScissorsEntitySystemTests
{
    [TestClass]
    public class FightSystemTest
    {
        EntityWorld world;
        FightSystem system;
        Mock<IRules> rulesMock;
        Entity player1Entity;
        Entity player2Entity;
        [TestInitialize]
        public void Initialize()
        {
            world = new EntityWorld();
            system = new FightSystem();
            rulesMock = new Mock<IRules>();
            rulesMock.Setup(m => m.GetScore(MoveType.Paper, MoveType.Rock)).Returns(1);
            system.Rules = rulesMock.Object;
            world.SystemManager.SetSystem(system, Artemis.Manager.GameLoopType.Update);
            player1Entity = world.CreateEntity();
            player1Entity.AddComponent(new Player("player1"));
            player1Entity.AddComponent(new Move() { MoveType = MoveType.Paper });
            player2Entity = world.CreateEntity();
            player2Entity.AddComponent(new Player("player2"));
            player2Entity.AddComponent(new Move() { MoveType = MoveType.Rock });
        }
        [TestMethod]
        public void ShouldCheckRulesForScore()
        {
            world.Update();
            rulesMock.Verify(m => m.GetScore(MoveType.Paper, MoveType.Rock));
            rulesMock.Verify(m => m.GetScore(MoveType.Rock, MoveType.Paper));
        }
        [TestMethod]
        public void PlayersScoreComponentsUpdated()
        {
            var score1 = player1Entity.GetComponent<Player>();
            var score2 = player2Entity.GetComponent<Player>();
            Assert.AreEqual(0, score1.Score);
            Assert.AreEqual(0, score2.Score);
            world.Update();
            Assert.AreEqual(1, score1.Score);
            Assert.AreEqual(0, score2.Score);
        }
    }
}
