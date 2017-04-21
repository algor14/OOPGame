using NConsoleGraphics;

namespace OOPGame {

  public class SamplePlayer : IGameObject {

    private ConsoleImage image;
    private int x, y;

    private int speed = 5;

    private bool wasLeftMouseButtonDown, wasRightMouseButtonDown;

    public SamplePlayer(ConsoleGraphics graphics) {

      image = graphics.LoadImage("pacman.png");
    }

    public void Render(ConsoleGraphics graphics) {

      graphics.DrawImage(image, x, y);
    }

    public void Update(GameEngine engine) {

      if (Input.IsKeyDown(Keys.LEFT))
        x -= speed;
      else if (Input.IsKeyDown(Keys.RIGHT))
        x += speed;

      if (Input.IsKeyDown(Keys.UP))
        y -= speed;
      else if (Input.IsKeyDown(Keys.DOWN))
        y += speed;

      if (!wasLeftMouseButtonDown && Input.IsMouseLeftButtonDown)
        engine.AddObject(new SampleBullet(x, y, speed));
      if (!wasRightMouseButtonDown && Input.IsMouseRightButtonDown)
        engine.AddObject(new SampleBullet(x, y, speed));

      wasLeftMouseButtonDown = Input.IsMouseLeftButtonDown;
      wasRightMouseButtonDown = Input.IsMouseRightButtonDown;
    }
  }
}