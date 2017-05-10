using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Snake : IGameObject
    {
        public ConsoleGraphics graphics;
        public List<SnakeItem> snake = new List<SnakeItem>();
        private int linkStep = 20;
        private int speed = 5;
        private CollisionDetector collissionDetector;

        public Snake(ConsoleGraphics graph, CollisionDetector detector)
        {
            graphics = graph;
            collissionDetector = detector;
            snake.Add(new SnakeHead(graphics, 200, 200));
            AddLink(4);
        }

        public IDrawedObject this[int index]
        {
            get
            {
                return snake[index];
            }
        }

        public int Count
        {
            get
            {
                return snake.Count;
            }
        }

        public void AddLink(int howMuch = 1)
        {
            int xStep = 0;
            int yStep = 0;
            for (int i = 0; i < howMuch; i++)
            {
                switch (snake[snake.Count - 1].direction)
                {
                    case Direction.Left:
                        xStep = linkStep;
                        break;
                    case Direction.Right:
                        xStep = -linkStep;
                        break;
                    case Direction.Up:
                        yStep = linkStep;
                        break;
                    case Direction.Down:
                        yStep = -linkStep;
                        break;
                }
                snake.Add(new SnakeItem(graphics, snake[snake.Count - 1].X + xStep, snake[snake.Count - 1].Y + yStep, snake[snake.Count - 1].direction));
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            foreach (var obj in snake)
                obj.Render(graphics);
        }

        public void Update(GameEngine engine)
        {
            snake[0].Update(engine, null, speed);
            for (int i = snake.Count - 1; i > 0; i--)
            {
                snake[i].Update(engine, snake[i - 1], speed);
                if (i > 3)
                {
                    if (collissionDetector.IsCollide(snake[0], snake[i]))
                    {
                        ((SnakeGameEngine)engine).Lose();
                    }
                }
            }
            if (collissionDetector.IsCollide(snake[0], ((SnakeGameEngine)engine).Food))
            {
                ((SnakeGameEngine)engine).EatFood();
                AddLink();
            }
            if (collissionDetector.checkWalls(snake[0]))
            {
                ((SnakeGameEngine)engine).Lose();
            }
        }

    }
}
