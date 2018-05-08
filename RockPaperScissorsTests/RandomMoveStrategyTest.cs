using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissors;

namespace RockPaperScissorsTests
{
    [TestClass]
    public class RandomMoveStrategyTest
    {

        [TestMethod]
        public void ShouldUseProvidedRandomGenerator()
        {
            var randomMock = new Moq.Mock<IRandom>();
            randomMock.Setup(m => m.Next(It.IsAny<int>(), It.IsAny<int>())).Returns(2);
            var randomMoveStrategy = new RandomMoveStrategy(randomMock.Object);
            var move = randomMoveStrategy.GetNext();
            Assert.AreEqual(Move.Paper, move);
            randomMock.VerifyAll();
        }
    }
}
