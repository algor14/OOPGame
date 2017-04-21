using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class SnakeItem
    {
        private ConsoleImage image;
        public int X { get; set; }
        public int Y { get; set; }
        public Direction direction = Direction.Left;

        public SnakeItem(ConsoleGraphics graphics, int x, int y)
        {
            X = x;
            Y = y;
            image = graphics.LoadImage("snakeLink.png");
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, X, Y);
        }

        public virtual void Update(GameEngine engine, SnakeItem prevItem, int speed)
        {
            switch (direction)
            {
                case Direction.Down:
                    Y += speed;
                    break;
                case Direction.Up:
                    Y -= speed;
                    break;
                case Direction.Left:
                    X -= speed;
                    break;
                case Direction.Right:
                    X += speed;
                    break;
            }
            switch(prevItem.direction)
            {
                case Direction.Down:
                    if(direction != Direction.Down && prevItem.X == X)
                            direction = prevItem.direction;
                    break;
                case Direction.Up:
                    if (direction != Direction.Up && prevItem.X == X)
                        direction = prevItem.direction;
                    break;
                case Direction.Left:
                    if (direction != Direction.Left && prevItem.Y == Y)
                        direction = prevItem.direction;
                    break;
                case Direction.Right:
                    if (direction != Direction.Right && prevItem.Y == Y)
                        direction = prevItem.direction;
                    break;
            }
            
        }
    }
}
