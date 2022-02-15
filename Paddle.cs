using Raylib_cs;

public class Paddle
{
    public int Height { get; set; }
    public Rectangle Rectangle { get; set; }
    public Color Color { get; set; } = Color.BLACK;
    public KeyboardKey Up { get; set; }
    public KeyboardKey Down { get; set; }

    public Paddle(KeyboardKey up, KeyboardKey down, int x, int y, int width, int height)
    {
        Up = up;
        Down = down;
        Rectangle = new(x, y, width, height);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(Rectangle, Color);
    }

    public void Input()
    {
        var posX = Rectangle.x;
        var posY = Rectangle.y;

        if(Raylib.IsKeyDown(Up))
            posY -= 10;
        if(Raylib.IsKeyDown(Down))
            posY += 10;
        
        posY = Math.Clamp(posY, 0, 600 - Rectangle.height);

        Rectangle = new(posX, posY, Rectangle.width, Rectangle.height);
    }
}