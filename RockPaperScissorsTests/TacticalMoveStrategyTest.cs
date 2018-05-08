using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors;

namespace RockPaperScissorsTests
{
    [TestClass]
    public class TacticalMoveStrategyTest
    {
        Mock<IRandom> randomMock;
        Mock<IRules> rulesMock;
        TacticalMoveStrategy tacticalStrategy;
        [TestInitialize]
        public void Initialize()
        {
            randomMock = new Moq.Mock<IRandom>();
            randomMock.Setup(m => m.Next(1, 3)).Returns((int)Move.Paper);
            rulesMock = new Moq.Mock<IRules>();
            tacticalStrategy = new TacticalMoveStrategy(randomMock.Object, rulesMock.Object);
        }
        [TestMethod]
        public void ShouldUseRandomForWhenFirstCalled()
        {
            var move = tacticalStrategy.GetNext();
            Assert.AreEqual(Move.Paper, move);
            randomMock.VerifyAll();
        }
        [TestMethod]
        public void ShouldNotUseRandomForSecondAndFutureCalls()
        {
            var move = tacticalStrategy.GetNext();
            randomMock.Verify(m => m.Next(1, 3), Times.Once());
            move = tacticalStrategy.GetNext();
            randomMock.Verify(m => m.Next(1, 3), Times.Once());
        }
        [TestMethod]
        public void ShouldUseRulesForSubsequentCalls()
        {
            var firstMove = tacticalStrategy.GetNext();
            rulesMock.Setup(m => m.GetWinningMove(Move.Paper)).Returns(Move.Scissors);
            var secondMove = tacticalStrategy.GetNext();
            Assert.AreEqual(Move.Scissors, secondMove);
            rulesMock.VerifyAll();
        }
    }
}
