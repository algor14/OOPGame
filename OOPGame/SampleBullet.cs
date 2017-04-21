using System;
using NConsoleGraphics;

namespace OOPGame {
  internal class SampleBullet : IGameObject {

    private int speed;
    private int x;
    private int y;

    public SampleBullet(int x, int y, int speed) {

      this.x = x;
      this.y = y;
      this.speed = speed;
    }

    public void Render(ConsoleGraphics graphics) {

      graphics.FillRectangle(0xFFFF0000, x, y, 5, 5);
    }

    public void Update(GameEngine engine) {

      x += speed;
      y += speed;
    }
  }
}