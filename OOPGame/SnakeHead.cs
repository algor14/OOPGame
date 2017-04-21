using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class SnakeHead : SnakeItem
    {
        private int pauseControl = 10; // delaye between key presses

        public SnakeHead(ConsoleGraphics graphics, int x, int y) 
            : base(graphics, x, y)
        {
        }

        public override void Update(GameEngine engine, SnakeItem prevItem, int speed)
        {
            //base.Update(engine, prevDirection, speed);
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
            HeadControl();
        }

        private void HeadControl()
        {
            if (pauseControl == 0)
            {
                if (Input.IsKeyDown(Keys.LEFT) && direction != Direction.Right)
                {
                    direction = Direction.Left;
                    pauseControl = 5;
                }
                else if (Input.IsKeyDown(Keys.RIGHT) && direction != Direction.Left)
                {
                    direction = Direction.Right;
                    pauseControl = 5;
                }
                else if (Input.IsKeyDown(Keys.UP) && direction != Direction.Down)
                {
                    direction = Direction.Up;
                    pauseControl = 5;
                }
                else if (Input.IsKeyDown(Keys.DOWN) && direction != Direction.Up)
                {
                    direction = Direction.Down;
                    pauseControl = 5;
                }
            }
            else
            {
                pauseControl--;
            }
        }
    }
}
