using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class Snake : IGameObject
    {
        public ConsoleGraphics graphics;
        public List<SnakeItem> snake = new List<SnakeItem>();
        private int linkStep = 20;
        private int speed = 5;
        private CollisionDetector collissionDetector;

        public Snake(ConsoleGraphics _graphics)
        {
            this.graphics = _graphics;
            snake.Add(new SnakeHead(graphics, 200, 200));
            AddItem(4);
            collissionDetector = new CollisionDetector(graphics);
        }

        public void AddItem( int howMuch  = 1)
        {
            for (int i = 0; i < howMuch; i++)
            {
                snake.Add(new SnakeItem(graphics, snake[snake.Count - 1].X + linkStep, snake[snake.Count - 1].Y));
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
                 snake[i].Update(engine, snake[i-1], speed);
            }
            if(collissionDetector.checkWalls(snake[0]))
            {
                //Console.WriteLine("Lose game");
            }
        }
    }
}
