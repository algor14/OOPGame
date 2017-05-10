using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class MainMenu : IGameObject
    {
        private ConsoleImage image;
        private ScoreManager scoreManager;
        private bool isHover = false;
        private int leftX = 0;
        private int topY = 0;
        private int curX = 0;
        private int curY = 0;

        public MainMenu(ConsoleGraphics graphics, ScoreManager scoreManager)
        {
            image = graphics.LoadImage("startgame.png");
            leftX = graphics.ClientWidth / 2 - image.Width / 2;
            topY = graphics.ClientHeight / 2 - image.Height / 2;
            this.scoreManager = scoreManager;
        }

        public void Render(ConsoleGraphics graphics)
        {
            if (isHover)
            {
                graphics.FillRectangle(0xFF00FF78, leftX, topY, image.Width - 10, image.Height - 20);
            }
            graphics.DrawImage(image, graphics.ClientWidth / 2 - image.Width / 2, graphics.ClientHeight / 2 - image.Height / 2);
            graphics.DrawString("Top Scores", "Arial", 0xFF00FF78, 350, 50, 24);
            graphics.DrawString(scoreManager.HighScores[0].ToString(), "Arial", 0xFF00FF78, 410, 80, 22);
            graphics.DrawString(scoreManager.HighScores[1].ToString(), "Arial", 0xFF00FF78, 410, 110, 22);
            graphics.DrawString(scoreManager.HighScores[2].ToString(), "Arial", 0xFF00FF78, 410, 140, 22);
            graphics.DrawString("Last Score:", "Arial", 0xFF00FF78, 330, 450, 24);
            graphics.DrawString(scoreManager.LastScore.ToString(), "Arial", 0xFF00FF78, 530, 450, 22);
        }

        public void Update(GameEngine engine)
        {
            curX = Input.MouseX;
            curY = Input.MouseY;
            if (curX > leftX && curX < (leftX + image.Width) && curY > topY && curY < (topY + image.Height))
            {
                isHover = true;
                if (Input.IsMouseLeftButtonDown)
                    ((SnakeGameEngine)engine).StartGame();
            }
            else
            {
                isHover = false;
            }
        }
    }
}
