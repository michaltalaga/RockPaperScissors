using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors;

namespace RockPaperScissorsTests
{
    [TestClass]
    public class HumanMoveStrategyTest
    {

        [TestMethod]
        public void ShouldReadUserInput()
        {
            var userInputMock = new Moq.Mock<IUserInput>();
            userInputMock.Setup(m => m.GetUserInput()).Returns('2');
            var humanStrategy = new HumanMoveStrategy(userInputMock.Object);
            var input = humanStrategy.GetNext();
            Assert.AreEqual(Move.Paper, input);
            userInputMock.VerifyAll();
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldChokeToDeathOnInvalidInput()
        {
            var userInputMock = new Moq.Mock<IUserInput>();
            userInputMock.Setup(m => m.GetUserInput()).Returns('a');
            var humanStrategy = new HumanMoveStrategy(userInputMock.Object);
            var input = humanStrategy.GetNext();
            userInputMock.VerifyAll();
        }
    }
}
