using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    public class CollisionDetector
    {
        private ConsoleGraphics graphics;

        public CollisionDetector(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }

        public bool checkWalls(SnakeItem item)
        {
            if (item.X < 10 || item.X > graphics.ClientWidth - 10 || item.Y < 10 || item.Y > graphics.ClientHeight - 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCollide(IDrawedObject obj1, IDrawedObject obj2)
        {
            return AxisXCollide(obj1, obj2) && AxisYCollide(obj1, obj2);
        }

        private bool AxisXCollide(IDrawedObject obj1, IDrawedObject obj2)
        {
            return (obj1.X >= obj2.X && obj1.X <= obj2.X + obj2.Width) || (obj1.X + obj1.Width >= obj2.X && obj1.X + obj1.Width <= obj2.X + obj2.Width);
        }

        private bool AxisYCollide(IDrawedObject obj1, IDrawedObject obj2)
        {
            return (obj1.Y >= obj2.Y && obj1.Y <= obj2.Y + obj2.Height) || (obj1.Y + obj1.Height >= obj2.Y && obj1.Y + obj1.Height <= obj2.Y + obj2.Height);
        }
    }
}
