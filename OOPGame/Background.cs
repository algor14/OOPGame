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
        private ConsoleGraphics graphics;
        public Background(ConsoleGraphics graph)
        {
            graphics = graph;
            image = graphics.LoadImage("board.png");           
        }

        public void Render(ConsoleGraphics graph)
        {
            graphics.DrawImage(image, 0, 0);
        }

        public void Update(GameEngine engine)
        {
            
        }
    }
}
