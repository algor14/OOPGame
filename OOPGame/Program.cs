using NConsoleGraphics;
using System;

namespace OOPGame {

    public class Program {

        //private static ConsoleImage image;

        static void Main(string[] args)
        {      
            Console.WindowWidth = 114;
            Console.WindowHeight = 54;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            SnakeGameEngine engine = new SnakeGameEngine(graphics);

            engine.Start();
        }
    }
}
