using Raylib_cs;
using r = Raylib_cs.Raylib;

#if DEBUG
r.SetTraceLogLevel(TraceLogLevel.LOG_DEBUG);
#else
r.SetTraceLogLevel(TraceLogLevel.LOG_NONE);
#endif

r.InitWindow(800, 600, ".NET Pong");
r.SetTargetFPS(60);

var paddle1 = new Paddle(KeyboardKey.KEY_W, KeyboardKey.KEY_S, 10, 10, 20, 50);
var paddle2 = new Paddle(KeyboardKey.KEY_UP, KeyboardKey.KEY_DOWN, 770, 10, 20, 50);
var ball = new Ball(400, 300, 20);

ball.RegisterPaddles(paddle1, paddle2);

while(!r.WindowShouldClose())
{
    r.BeginDrawing();
    r.ClearBackground(Color.RAYWHITE);

    paddle1.Draw();
    paddle2.Draw();
    ball.Draw();

    r.EndDrawing();

    paddle1.Input();
    paddle2.Input();
    ball.Input();
}
