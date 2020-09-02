using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private readonly Game game;
        public GameFixture()
        {
            game = new Game();
        }

        [Fact]
        public void Test_Roll_with_NotImplemented_Exception()
        {
            Assert.Throws<NotImplementedException>(() => game.Roll(0));
        }

        [Fact]
        public void Test_GetScore_with_return_0()
        {
            Assert.Equal(0, game.GetScore());
        }
    }
}
