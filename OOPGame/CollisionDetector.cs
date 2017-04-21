using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    internal class CollisionDetector
    {
        public ConsoleGraphics graphics;

        public CollisionDetector(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }
        internal bool checkWalls(SnakeItem item)
        {
            if (item.X < 10 || item.X > graphics.ClientWidth-10 || item.Y < 10 || item.Y > graphics.ClientHeight - 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
