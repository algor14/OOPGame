using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class SnakeItem : IDrawedObject, IGameObject
    {
        private ConsoleImage image;
        protected Snake snake;
        private SnakeItem prevItem;
        protected int speed = 0;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; }
        public int Height { get; }
        public Direction direction;

        public SnakeItem(Snake snake, SnakeItem prevItem, ConsoleGraphics graphics, int x, int y, Direction direction = Direction.Left)
        {
            X = x;
            Y = y;
            image = graphics.LoadImage("snakeLink.png");
            Width = image.Width;
            Height = image.Height;
            this.direction = direction;
            this.snake = snake;
            this.prevItem = prevItem;
            speed = snake.speed;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, X, Y);
        }

        public virtual void Update(GameEngine engine)
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
            switch (prevItem.direction)
            {
                case Direction.Down:
                    if (direction != Direction.Down && prevItem.X == X)
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
