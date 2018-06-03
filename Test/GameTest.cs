using System;
using dz2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Random r = new Random();
            var x = r.Next(21);
            var y = r.Next(21);
            var v = r.Next(2);
            var testGame = new GameFake();
            var game = new Game(testGame.GetGame());

            // Act
            game.nextStep(x,y,v);

            //Assert 
            Assert.IsNotNull(game.Mas);
        }
    }
}
