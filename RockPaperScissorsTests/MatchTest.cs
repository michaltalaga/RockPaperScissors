using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors;
using System.Linq;
using Moq;
using System.Collections.Generic;

namespace RockPaperScissorsTests
{
    [TestClass]
    public class MatchTest
    {
        Moq.Mock<IPlayer> rockPlayerMock;
        Moq.Mock<IPlayer> paperPlayerMock;
        Moq.Mock<IRules> rulesMock;

        [TestInitialize]
        public void Initialize()
        {
            rockPlayerMock = new Moq.Mock<IPlayer>();
            rockPlayerMock.Setup(m => m.Move()).Returns(Move.Rock);
            paperPlayerMock = new Moq.Mock<IPlayer>();
            paperPlayerMock.Setup(m => m.Move()).Returns(Move.Paper);
            rulesMock = new Moq.Mock<IRules>();
            rulesMock.Setup(m => m.GetScore(Move.Rock, Move.Paper)).Returns(-1);
        }
        [TestMethod]
        public void MatchResultsHaveCorrectNumberOfRounds()
        {
            var match = new RockPaperScissors.Match(rulesMock.Object);
            var results = match.Play(5, rockPlayerMock.Object, paperPlayerMock.Object);
            Assert.AreEqual(5, results.Rounds.Count());
            results = match.Play(3, rockPlayerMock.Object, paperPlayerMock.Object);
            Assert.AreEqual(3, results.Rounds.Count());
        }
        [TestMethod]
        public void ShouldUsePlayersMovesEachRound()
        {
            var match = new RockPaperScissors.Match(rulesMock.Object);
            var results = match.Play(3, rockPlayerMock.Object, paperPlayerMock.Object);
            rockPlayerMock.Verify(m => m.Move(), Times.Exactly(3));
            paperPlayerMock.Verify(m => m.Move(), Times.Exactly(3));
        }
        [TestMethod]
        public void ShouldUseRulesEachRound()
        {
            var match = new RockPaperScissors.Match(rulesMock.Object);
            var results = match.Play(3, rockPlayerMock.Object, paperPlayerMock.Object);
            rulesMock.Verify(m => m.GetScore(It.IsAny<Move>(), It.IsAny<Move>()), Times.Exactly(3));
        }
        [TestMethod]
        public void ProducesRoundsWithCorrectResults()
        {
            var match = new RockPaperScissors.Match(rulesMock.Object);
            var results = match.Play(3, rockPlayerMock.Object, paperPlayerMock.Object);
            var firstRound = results.Rounds.First();
            Assert.AreEqual(Move.Rock, firstRound.Player1Move);
            Assert.AreEqual(Move.Paper, firstRound.Player2Move);
            Assert.AreEqual(-1, firstRound.Player1Score);
            Assert.AreEqual(1, firstRound.Player2Score);
        }
        [TestMethod]
        public void EachRoundRaisesRoundPlayedEvent()
        {
            var rounds = new List<MatchResults.Round>();
            var match = new RockPaperScissors.Match(rulesMock.Object);
            match.RoundPlayed += (o, e) =>
            {
                rounds.Add(e.Round);
            };
            match.Play(3, rockPlayerMock.Object, paperPlayerMock.Object);
            Assert.AreEqual(3, rounds.Count);
        }
    }
}
