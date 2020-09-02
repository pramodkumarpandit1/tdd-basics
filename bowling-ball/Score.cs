namespace BowlingBall
{
    public class Score
    {
        private int ball;
        private readonly int[] rolls = new int[21];
        private int currentRoll;
        public void AddRoll(int pins) { rolls[currentRoll++] = pins; }
        public int ScoreForFrame(int nFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < nFrame; currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + NextTwoBallsForStrike; ball++;
                }
                else if (Spare())
                { score += 10 + NextBallForSpare; ball += 2; }
                else { score += TwoBallsInFrame; ball += 2; }
            }
            return score;
        }
        private int NextTwoBallsForStrike => (rolls[ball + 1] + rolls[ball + 2]);
        private int NextBallForSpare => rolls[ball + 2];
        private bool Strike() { return rolls[ball] == 10; }
        private int TwoBallsInFrame => rolls[ball] + rolls[ball + 1];
        private bool Spare()
        {
            return rolls[ball] + rolls[ball + 1] == 10;
        }
    }
}
