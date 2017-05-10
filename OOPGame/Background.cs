using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class Background : IGameObject
    {
        private ConsoleImage image;

        public Background(ConsoleGraphics graphics)
        {
            image = graphics.LoadImage("board.png");
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawImage(image, 0, 0);
        }
        public void Update(GameEngine engine)
        {
            
        }
    }
}
