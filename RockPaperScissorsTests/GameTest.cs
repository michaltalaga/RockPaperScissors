//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using RockPaperScissors;

//namespace RockPaperScissorsTests
//{
//    [TestClass]
//    public class GameTest
//    {
//        Moq.Mock<IPlayer> rockPlayer;
//        Moq.Mock<IPlayer> paperPlayer;

//        [TestInitialize]
//        public void Initialize()
//        {
//            rockPlayer = new Moq.Mock<IPlayer>();
//            rockPlayer.Setup(m => m.Move()).Returns(Move.Rock);
//            paperPlayer = new Moq.Mock<IPlayer>();
//            paperPlayer.Setup(m => m.Move()).Returns(Move.Paper);
//        }
//        [TestMethod]
//        public void ShouldCheckPlayersMoves()
//        {
//            var game = new Game(1, rockPlayer.Object, paperPlayer.Object);
//            game.Resolve();
//            Assert.AreEqual(Move.Rock, game.Player1Move);
//            Assert.AreEqual(Move.Paper, game.Player2Move);

//            rockPlayer.VerifyAll();
//            paperPlayer.VerifyAll();
//        }
//        [TestMethod]
//        [ExpectedException(typeof(InvalidOperationException))]
//        public void CannotResolveSameGameTwice()
//        {
//            var game = new Game(1, rockPlayer.Object, paperPlayer.Object);
//            game.Resolve();
//            game.Resolve();
//        }

//    }
//}
