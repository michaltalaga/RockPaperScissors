using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors;

namespace RockPaperScissorsTests
{
    [TestClass]
    public class PlayerTest
    {

        [TestMethod]
        public void ShowHandShouldUseProvidedStrategy()
        {
            var strategyMock = new Moq.Mock<IMoveStrategy>();
            strategyMock.Setup(m => m.GetNext()).Returns(Move.Paper);
            var player = new Player("dummy", strategyMock.Object);
            var move = player.Move();
            Assert.AreEqual(Move.Paper, move);
            strategyMock.VerifyAll();
        }
       

    }
}
