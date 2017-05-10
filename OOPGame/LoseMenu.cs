using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;
using System.Threading;

namespace OOPGame
{
    public class LoseMenu : IGameObject
    {
        private ConsoleImage image;
        private int leftX = 0;
        private int topY = 0;

        public LoseMenu(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("gameover.png");
            leftX = graphics.ClientWidth / 2 - image.Width / 2;
            topY = graphics.ClientHeight / 2 - image.Height / 2;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, graphics.ClientWidth / 2 - image.Width / 2, graphics.ClientHeight / 2 - image.Height / 2);
        }

        public void Update(GameEngine engine)
        {
            Thread.Sleep(1000);
            ((SnakeGameEngine)engine).Restart();
        }
    }
}
