using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class MainMenu : IGameObject
    {
        //ConsoleGraphics graphic;
        private ConsoleImage image;
        private bool wasClicked = false;
        private bool isHover = false;
        private int leftX = 0;
        private int topY = 0;
        private int curX = 0;
        private int curY = 0;

        public MainMenu(ConsoleGraphics graphics)
        {
            //this.graphic = graphic;
            image = graphics.LoadImage("startgame.png");
            leftX = graphics.ClientWidth / 2 - image.Width / 2;
            topY = graphics.ClientHeight / 2 - image.Height / 2;
        }

        public void Render(ConsoleGraphics graphics)
        {
            if (isHover)
            {
                graphics.FillRectangle(0xFF00FF78, leftX, topY, image.Width - 10, image.Height - 20);
            }                        
            graphics.DrawImage(image, graphics.ClientWidth/2 - image.Width/2, graphics.ClientHeight / 2 - image.Height / 2);           
        }

        public void Update(GameEngine engine)
        {
            curX = Input.MouseX;
            curY = Input.MouseY;
            if (curX > leftX && curX < (leftX + image.Width) && curY > topY && curY < (topY + image.Height))
            {
                isHover = true;
                if (Input.IsMouseLeftButtonDown)
                {
                    SnakeGameEngine snakeEngine = (SnakeGameEngine)engine;
                    snakeEngine.StartGame();                 
                }
            }
            else
            {
                isHover = false;
            }
        }
    }
}
