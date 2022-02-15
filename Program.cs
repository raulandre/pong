using Raylib_cs;
using r = Raylib_cs.Raylib;

#if DEBUG
r.SetTraceLogLevel(TraceLogLevel.LOG_DEBUG);
#else
r.SetTraceLogLevel(TraceLogLevel.LOG_NONE);
#endif

r.InitWindow(800, 600, ".NET Pong");
r.SetTargetFPS(60);

var paddle1 = new Paddle(KeyboardKey.KEY_W, KeyboardKey.KEY_S, 10, 275, 20, 50);
var paddle2 = new Paddle(KeyboardKey.KEY_UP, KeyboardKey.KEY_DOWN, 770, 275, 20, 50);
var ball = new Ball(400, 300, 20);

var goal1 = new Rectangle(0, 0, 10, 600);
var goal2 = new Rectangle(790, 0, 10, 600);
var score = (0, 0);


void ResetBall()
{
    ball = new Ball(400, 300, 20);
    ball.RegisterPaddles(paddle1, paddle2);
}

ResetBall();

while(!r.WindowShouldClose())
{
    r.BeginDrawing();
    r.ClearBackground(Color.RAYWHITE);
    r.DrawLine(400, 0, 400, 600, Color.BLACK);

    paddle1.Draw();
    paddle2.Draw();
    ball.Draw();

    r.DrawText(score.Item1.ToString(), 350, 10, 20, Color.RED);
    r.DrawText(score.Item2.ToString(), 430, 10, 20, Color.RED);


    if(r.CheckCollisionCircleRec(new(ball.PosX, ball.PosY), ball.Radius, goal1))
    {
        ResetBall();
        score.Item1++;
    }
    else if(r.CheckCollisionCircleRec(new(ball.PosX, ball.PosY), ball.Radius, goal2))
    {
        ResetBall();
        score.Item2++;
    }

    r.EndDrawing();

    paddle1.Input();
    paddle2.Input();
    ball.Input();
}
