namespace BowlingBall
{
    public class Game
    {
        private int currentFrame = 0;
        private bool isFirstRoll = true;
        private Score score = new Score();
        public int Score => GetScore(currentFrame);
        public void Rolls(int pins)
        {
            score.AddRoll(pins);
            CalculateCurrentFrame(pins);
        }
        private void CalculateCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
            {
                CalculateFrame();
            }
            else
            {
                isFirstRoll = false;
            }
        }
        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!isFirstRoll);
        }
        private bool Strike(int pins)
        {
            return (isFirstRoll && pins == 10);
        }
        private void CalculateFrame()
        {
            currentFrame++; if (currentFrame > 10)
            { currentFrame = 10; }
        }
        public int GetScore(int nFrame)
        {
            return score.ScoreForFrame(nFrame);
        }

    }
}

