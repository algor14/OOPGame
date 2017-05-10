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
        private IGameObject food;
        private CollisionDetector collissionDetector;
        private ScoreManager scoreManager;

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
            if (stage == Location.Game)
            {
                scoreManager.SetScore(snake.Count * 50);
                stage = Location.LoseMenu;
                RemoveObject(snake);
                RemoveObject(food);
                loseMenu = new LoseMenu(graphics);
                AddObject(loseMenu);
            }
        }

    }
}
