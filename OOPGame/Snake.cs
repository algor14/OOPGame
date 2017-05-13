using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Snake
    {
        public ConsoleGraphics graphics;
        public List<SnakeItem> snake = new List<SnakeItem>();
        private int linkStep = 20;
        public int speed = 5;
        private CollisionDetector collissionDetector;
        private SnakeGameEngine engine;

        public Snake(SnakeGameEngine engine, ConsoleGraphics graph, CollisionDetector detector)
        {
            graphics = graph;
            collissionDetector = detector;
            this.engine = engine;
            snake.Add(new SnakeHead(this, null, collissionDetector, graphics, 200, 200));
            for (int i = 0; i < 4; i++)
                AddLink();
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

        public SnakeItem AddLink()
        {
            int xStep = 0;
            int yStep = 0;
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
            SnakeItem snkLink = new SnakeItem(this, snake[Count - 1], graphics, snake[snake.Count - 1].X + xStep, snake[snake.Count - 1].Y + yStep, snake[snake.Count - 1].direction);
            snake.Add(snkLink);
            return snkLink;
        }

        public void EatFood()
        {
            engine.EatFood(AddLink());
        }

        public void Lose()
        {
            engine.Lose();
        }

    }
}
