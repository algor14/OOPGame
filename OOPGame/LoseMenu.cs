using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class LoseMenu : IGameObject
    {
        //ConsoleGraphics graphic;
        private ConsoleImage image;
        private int leftX = 0;
        private int topY = 0;
        private int curX = 0;
        private int curY = 0;

        public LoseMenu(ConsoleGraphics graphics)
        {
            //this.graphic = graphic;
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
            curX = Input.MouseX;
            curY = Input.MouseY;
            if (curX > leftX && curX < (leftX + image.Width) && curY > topY && curY < (topY + image.Height))
            {
                if (Input.IsMouseLeftButtonDown)
                {
                    ((SnakeGameEngine)engine).StartGame();
                }
            }
            
        }
    }
}
