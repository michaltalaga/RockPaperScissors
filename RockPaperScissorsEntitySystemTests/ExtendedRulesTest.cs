using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissorsEntitySystem;
using RockPaperScissorsEntitySystem.Components;

namespace RockPaperScissorsEntitySystemTests
{
    [TestClass]
    public class ExtendedRulesTest
    {
        ExtendedRules rules;

        [TestInitialize]
        public void Initialize()
        {
            rules = new ExtendedRules();
        }
        [TestMethod]
        public void Scores0ForSameMoves()
        {
            Assert.AreEqual(0, rules.GetScore(MoveType.Rock, MoveType.Rock));
            Assert.AreEqual(0, rules.GetScore(MoveType.Paper, MoveType.Paper));
            Assert.AreEqual(0, rules.GetScore(MoveType.Scissors, MoveType.Scissors));
            Assert.AreEqual(0, rules.GetScore(MoveType.Lizard, MoveType.Lizard));
            Assert.AreEqual(0, rules.GetScore(MoveType.Spock, MoveType.Spock));
        }
        [TestMethod]
        public void RockWinsScore1()
        {
            Assert.AreEqual(1, rules.GetScore(MoveType.Rock, MoveType.Scissors));
            Assert.AreEqual(1, rules.GetScore(MoveType.Rock, MoveType.Lizard));
        }
        [TestMethod]
        public void PaperWinsScore1()
        {
            Assert.AreEqual(1, rules.GetScore(MoveType.Paper, MoveType.Rock));
            Assert.AreEqual(1, rules.GetScore(MoveType.Paper, MoveType.Spock));
        }
        [TestMethod]
        public void ScissorsWinScore1()
        {
            Assert.AreEqual(1, rules.GetScore(MoveType.Scissors, MoveType.Paper));
            Assert.AreEqual(1, rules.GetScore(MoveType.Scissors, MoveType.Lizard));
        }
        [TestMethod]
        public void LizzardWinsScore1()
        {
            Assert.AreEqual(1, rules.GetScore(MoveType.Lizard, MoveType.Paper));
            Assert.AreEqual(1, rules.GetScore(MoveType.Lizard, MoveType.Spock));
        }
        [TestMethod]
        public void SpockWinsScore1()
        {
            Assert.AreEqual(1, rules.GetScore(MoveType.Spock, MoveType.Scissors));
            Assert.AreEqual(1, rules.GetScore(MoveType.Spock, MoveType.Rock));
        }
        [TestMethod]
        public void ScoresAreMirrored()
        {
            Assert.AreEqual(1, rules.GetScore(MoveType.Rock, MoveType.Scissors));
            Assert.AreEqual(-1, rules.GetScore(MoveType.Scissors, MoveType.Rock));
            Assert.AreEqual(1, rules.GetScore(MoveType.Spock, MoveType.Rock));
            Assert.AreEqual(-1, rules.GetScore(MoveType.Rock, MoveType.Spock));
        }
        [TestMethod]
        public void GetWinningMoveReturnsCorrectResult()
        {
            Assert.AreEqual(MoveType.Paper, rules.GetWinningMove(MoveType.Rock));
            Assert.AreEqual(MoveType.Scissors, rules.GetWinningMove(MoveType.Paper));
            Assert.AreEqual(MoveType.Rock, rules.GetWinningMove(MoveType.Scissors));
            Assert.AreEqual(MoveType.Rock, rules.GetWinningMove(MoveType.Lizard));
            Assert.AreEqual(MoveType.Paper, rules.GetWinningMove(MoveType.Spock));
        }
    }
}
