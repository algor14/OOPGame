using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Food : IGameObject, IDrawedObject
    {
        private ConsoleImage image;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; }
        public int Height { get; }
        private CollisionDetector collissionDetector;
        private Snake snake;
        private ConsoleGraphics graphics;

        public Food(ConsoleGraphics graphics, CollisionDetector collissionDetector, Snake snake)
        {
            this.graphics = graphics;
            this.collissionDetector = collissionDetector;
            this.snake = snake;
            image = graphics.LoadImage("foodItem1.png");
            Width = image.Width;
            Height = image.Height;
            SetCoordOfFood();
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, X, Y);
        }

        public void Update(GameEngine engine)
        {

        }
        private void SetCoordOfFood()
        {
            bool rightPosition = false;           
            Random rnd = new Random();
            while (!rightPosition)
            {
                bool isCollided = false;
                X = rnd.Next(50, graphics.ClientWidth - 50);
                Y = rnd.Next(50, graphics.ClientHeight - 50);
                for (int i = 0; i < snake.Count; i++)
                {
                    if (collissionDetector.IsCollide(this, snake[i]))
                        isCollided = true;
                }
                rightPosition = !isCollided;
            }
        }
    }
}
