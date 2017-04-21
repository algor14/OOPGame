using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame {

  public class SnakeGameEngine : GameEngine {
        ConsoleGraphics graphics;
        private IGameObject menu;
        private IGameObject snake;
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
            if(stage == "Menu")
            {
                stage = "Game";
                RemoveObject(menu);
                snake = new Snake(graphics);
                AddObject(snake);
            }           
        }

    }
}
