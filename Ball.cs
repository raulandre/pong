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
    public bool Stuck { get; set; }

    public Ball(int posX, int posY, int radius)
    {
        PosX = posX;
        PosY = posY;
        Radius = radius;
        Stuck = true;
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
                SpeedX = new Random().Next(0, 2) == 0 ? -10 : 10;
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
                    if(SpeedY == 0) SpeedY = 3;

                    SpeedY = new Random().Next(0, 2) == 0 ? -SpeedY : SpeedY;
                    SpeedY += new Random().Next(0, 6);

                    PosX += SpeedX;
                    PosY += SpeedY;
                } else {
                    PosX += SpeedX;
                    PosY += SpeedY;
                }
            
            if(PosY + Radius <= 0 || PosY + Radius >= 600)
                SpeedY = -SpeedY;
            if(PosX - Radius <= 0 || PosX + Radius >= 800)
                SpeedX = -SpeedX;
        }
        Raylib.DrawCircle(PosX, PosY, Radius, Color);
    }
}
