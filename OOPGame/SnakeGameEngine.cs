using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{

    public class SnakeGameEngine : GameEngine
    {
        private ConsoleGraphics graphics;
        private IGameObject menu;
        private IGameObject snake;
        private IGameObject loseMenu;
        private IGameObject food;
        private CollisionDetector collissionDetector;

        public SnakeGameEngine(ConsoleGraphics graphics)
            : base(graphics)
        {
            this.graphics = graphics;
            AddObject(new Background(graphics));
            //AddObject(new SamplePlayer(graphics));
            //AddObject(new Snake(graphics));
            menu = new MainMenu(graphics);
            AddObject(menu);
        }
        /*public override void Start()
        {
            base.Start();           
        }*/
        public void StartGame()
        {
            if (stage == "Menu")
            {
                stage = "Game";
                RemoveObject(menu);
                collissionDetector = new CollisionDetector(graphics);
                snake = new Snake(graphics, collissionDetector);
                AddObject(snake);
                ThrowFood();
            }
        }

        public void ThrowFood()
        {
            food = new Food(graphics, collissionDetector, snake);
            AddObject(food);
        }
        public void EatFood()
        {
            RemoveObject(food);
            ThrowFood();
        }
        public Food Food
        {
            get
            {
                return food as Food;
            }
        }

        public void Lose()
        {
            if (stage == "Game")
            {
                stage = "LoseMenu";
                RemoveObject(snake);
                loseMenu = new LoseMenu(graphics);
                AddObject(loseMenu);
            }
        }

    }
}
