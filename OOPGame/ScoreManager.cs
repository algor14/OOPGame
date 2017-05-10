using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public class ScoreManager
    {
        public int[] HighScores { get; set; }
        public int LastScore { get; set; }
        private string[] scoreStrings;

        public ScoreManager()
        {
            HighScores = new int[3] { 0, 0, 0 };
            if (File.Exists("scores.txt"))
            {
                scoreStrings = File.ReadAllLines("scores.txt");
                LastScore = int.Parse(scoreStrings[0]);
                for (int i = 1; i < scoreStrings.Length; i++)
                {
                    HighScores[i - 1] = int.Parse(scoreStrings[i]);
                }
            }
            else
            {
                scoreStrings = new string[4] { "0", "0", "0", "0" };
                File.WriteAllLines("scores.txt", scoreStrings);
            }
        }

        public void SetScore(int score)
        {
            if (HighScores[HighScores.Length - 1] < score)
            {
                HighScores[HighScores.Length - 1] = score;
                Array.Sort(HighScores, (a, b) => b - a);
            }
            LastScore = score;
            scoreStrings = new string[4] { LastScore.ToString(), "", "", "" };
            for (int i = 1; i < scoreStrings.Length; i++)
                scoreStrings[i] = HighScores[i - 1].ToString();
            File.WriteAllLines("scores.txt", scoreStrings);
        }
    }
}
