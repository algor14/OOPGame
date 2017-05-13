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
        private const int PAUSE_DELAY = 6;
        private int pauseControl; // delay between key presses
        private CollisionDetector collissionDetector;

        public SnakeHead(Snake snake, SnakeItem prevItem, CollisionDetector collissionDetector, ConsoleGraphics graphics, int x, int y)
            : base(snake, prevItem, graphics, x, y)
        {
            pauseControl = 0;
            this.collissionDetector = collissionDetector;
        }

        public override void Update(GameEngine engine)
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
            //Check collisions
            for (int i = snake.Count - 1; i > 3; i--)
                if (collissionDetector.IsCollide(snake[0], snake[i]))
                    snake.Lose();
            if (collissionDetector.IsCollide(this, ((SnakeGameEngine)engine).Food))
                ((SnakeGameEngine)engine).EatFood(snake.AddLink());
            if (collissionDetector.checkWalls(this))
                ((SnakeGameEngine)engine).Lose();
            HeadControl();
        }

        private void HeadControl()
        {
            if (pauseControl == 0)
            {
                if (Input.IsKeyDown(Keys.LEFT) && direction != Direction.Right)
                {
                    direction = Direction.Left;
                    pauseControl = PAUSE_DELAY;
                }
                else if (Input.IsKeyDown(Keys.RIGHT) && direction != Direction.Left)
                {
                    direction = Direction.Right;
                    pauseControl = PAUSE_DELAY;
                }
                else if (Input.IsKeyDown(Keys.UP) && direction != Direction.Down)
                {
                    direction = Direction.Up;
                    pauseControl = PAUSE_DELAY;
                }
                else if (Input.IsKeyDown(Keys.DOWN) && direction != Direction.Up)
                {
                    direction = Direction.Down;
                    pauseControl = PAUSE_DELAY;
                }
            }
            else
            {
                pauseControl--;
            }
        }
    }
}
