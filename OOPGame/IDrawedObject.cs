using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
    public interface IDrawedObject
    {
        int X { get; set; }
        int Y { get; set; }
        int Width { get; }
        int Height { get; }
    }
}
