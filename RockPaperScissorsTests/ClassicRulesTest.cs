using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors;

namespace RockPaperScissorsTests
{
    [TestClass]
    public class ClassicRulesTest
    {
        ClassicRules rules;
        [TestInitialize]
        public void Initialize()
        {
            rules = new ClassicRules();
        }

        [TestMethod]
        public void RockRulesCorrect()
        {
            Assert.AreEqual(0, rules.GetScore(Move.Rock, Move.Rock));
            Assert.AreEqual(-1, rules.GetScore(Move.Rock, Move.Paper));
            Assert.AreEqual(1, rules.GetScore(Move.Rock, Move.Scissors));
        }
        [TestMethod]
        public void PaperRulesCorrect()
        {
            Assert.AreEqual(1, rules.GetScore(Move.Paper, Move.Rock));
            Assert.AreEqual(0, rules.GetScore(Move.Paper, Move.Paper));
            Assert.AreEqual(-1, rules.GetScore(Move.Paper, Move.Scissors));
        }
        
        [TestMethod]
        public void ScissorsRulesCorrect()
        {
            Assert.AreEqual(-1, rules.GetScore(Move.Scissors, Move.Rock));
            Assert.AreEqual(1, rules.GetScore(Move.Scissors, Move.Paper));
            Assert.AreEqual(0, rules.GetScore(Move.Scissors, Move.Scissors));
        }
        [TestMethod]
        public void FindsCorrectWinningMove()
        {
            Assert.AreEqual(Move.Paper, rules.GetWinningMove(Move.Rock));
            Assert.AreEqual(Move.Scissors, rules.GetWinningMove(Move.Paper));
            Assert.AreEqual(Move.Rock, rules.GetWinningMove(Move.Scissors));
        }
    }
}
