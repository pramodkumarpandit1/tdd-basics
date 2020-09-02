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
        public void Test_GetScore_with_return_0()
        {
            Assert.Equal(0, game.GetScore(0));
        }

        [Fact]
        public void Test_TwoRolls_NoMark()
        {
            game.Rolls(5);
            game.Rolls(4);
            Assert.Equal(9, game.Score);
        }

        [Fact]
        public void Test_FourRolls_NoMark()
        {
            game.Rolls(5);
            game.Rolls(4);
            game.Rolls(7);
            game.Rolls(2);
            Assert.Equal(18, game.Score);
            Assert.Equal(9, game.GetScore(1));
            Assert.Equal(18, game.GetScore(2));
        }

        [Fact]
        public void Test_Simple_Spare()
        {
            game.Rolls(3);
            game.Rolls(7);
            game.Rolls(3);
            Assert.Equal(13, game.GetScore(1));
        }

        [Fact]
        public void Test_SimpleFrame_AfterSpare()
        {
            game.Rolls(3);
            game.Rolls(7);
            game.Rolls(3);
            game.Rolls(2);
            Assert.Equal(13, game.GetScore(1));
            Assert.Equal(18, game.GetScore(2));
            Assert.Equal(18, game.Score);
        }

        [Fact]
        public void Test_Simple_Strike()
        {
            game.Rolls(10);
            game.Rolls(3);
            game.Rolls(6);
            Assert.Equal(19, game.GetScore(1));
            Assert.Equal(28, game.Score);
        }

        [Fact]
        public void Test_Exact_Game()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Rolls(10);
            }
            Assert.Equal(300, game.Score);
        }

        [Fact]
        public void Test_EndOfFrame()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Rolls(0);
                game.Rolls(0);
            }
            game.Rolls(2);
            game.Rolls(8);

            // 10th frame spare   
            game.Rolls(10);

            // Strike in last position of array.   
            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void Test_Sample_Game()
        {
            game.Rolls(1);
            game.Rolls(4);
            game.Rolls(4);
            game.Rolls(5);
            game.Rolls(6);
            game.Rolls(4);
            game.Rolls(5);
            game.Rolls(5);
            game.Rolls(10);
            game.Rolls(0);
            game.Rolls(1);
            game.Rolls(7);
            game.Rolls(3);
            game.Rolls(6);
            game.Rolls(4);
            game.Rolls(10);
            game.Rolls(2);
            game.Rolls(8);
            game.Rolls(6);
            Assert.Equal(133, game.Score);
        }

        [Fact]
        public void Test_AllRoll_As_Strikes()
        {
            for (int i = 0; i < 11; i++)
            {
                game.Rolls(10);
            }
            game.Rolls(9);
            Assert.Equal(299, game.Score);
        }

        [Fact]
        public void Test_Tenth_Frame_As_Spare()
        {
            for (int i = 0; i < 9; i++)
            {
                game.Rolls(10);
            }
            game.Rolls(9);
            game.Rolls(1);
            game.Rolls(1);
            Assert.Equal(270, game.Score);
        }
    }
}
