using Raylib_cs;

public class Ball
{
    private List<Paddle> _paddles = new();

    public int PosX { get; set; }
    public int PosY { get; set; }
    public int SpeedX { get; set; }
    public int SpeedY { get; set; }
    public int Radius { get; set; }
    public Color Color { get; set; } = Color.RED;
    public bool Stuck { get; set; } = true;

    public Ball(int posX, int posY, int radius)
    {
        PosX = posX;
        PosY = posY;
        Radius = radius;
    }

    public void RegisterPaddles(params Paddle[] paddles)
    {
        _paddles.AddRange(paddles);
    }

    public void Input()
    {
        if(Raylib.GetKeyPressed() == ((int)KeyboardKey.KEY_SPACE))
            if(Stuck)
            {
                Stuck = false;
                SpeedX = -10;
            }
    }

    public void Draw()
    {
        if(!Stuck)
        {
            foreach(var paddle in _paddles)
                if(Raylib.CheckCollisionCircleRec(new(PosX, PosY), Radius, paddle.Rectangle))
                {
                    SpeedX = -SpeedX;
                    SpeedY = -SpeedY;

                    PosX += SpeedX;
                    PosY += SpeedY;
                } else {
                    PosX += SpeedX;
                    PosY += SpeedY;
                }
        }
        Raylib.DrawCircle(PosX, PosY, Radius, Color);
    }
}
