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
        private IGameObject mainMenu;
        private Snake snake;
        private IGameObject loseMenu;
        private Food food;
        private CollisionDetector collissionDetector;
        private ScoreManager scoreManager;
        public Location stage = Location.MainMenu;

        public SnakeGameEngine(ConsoleGraphics graphics)
            : base(graphics)
        {
            this.graphics = graphics;
            scoreManager = new ScoreManager();
            AddNewMenu();
        }

        public override void Restart()
        {
            base.Restart();
            AddNewMenu();
            Start();
        }

        private void AddNewMenu()
        {
            AddObject(new Background(graphics));
            mainMenu = new MainMenu(graphics, scoreManager);
            AddObject(mainMenu);
            stage = Location.MainMenu;
        }

        public void StartGame()
        {
            if (stage == Location.MainMenu)
            {
                stage = Location.Game;
                RemoveObject(mainMenu);
                collissionDetector = new CollisionDetector(graphics);
                snake = new Snake(this, graphics, collissionDetector);
                foreach (var item in snake.snake)
                    AddObject(item);             
                ThrowFood();
            }
        }

        public void ThrowFood()
        {
            food = new Food(graphics, collissionDetector, snake);
            AddObject(food);
        }

        public void EatFood(IGameObject obj)
        {
            RemoveObject(food);
            ThrowFood();
            AddObject(obj);
        }

        public Food Food
        {
            get
            {
                return food;
            }
        }

        public void Lose()
        {
            if (stage == Location.Game)
            {
                scoreManager.SetScore(snake.Count * 50);
                stage = Location.LoseMenu;
                foreach (var item in snake.snake)
                    RemoveObject(item);
                RemoveObject(food);
                loseMenu = new LoseMenu(graphics);
                AddObject(loseMenu);
            }
        }

    }
}
