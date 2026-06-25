using Godot;

public partial class Main : Node2D
{
    int Score = 0;
    public int LifeCount = 3;
    public Vector2 ScreenSize;
    private Hud Hud;
    
    public override void _Ready()
    {
        Hud = GetNode<Hud>("Hud");
        Hud.UpdateLifeCount(LifeCount);
    }

    public override void _Process(double delta)
    {
        ScreenSize = GetViewportRect().Size;
        Ball ball = GetNode<Ball>("Ball");
        if(ball.Position.Y > ScreenSize.Y & LifeCount > 0)
        {
            DecreaseLifeCount();
            if(LifeCount > 0)
            {
                ball.Serve();
            }
            ball.IsFollowing = true;
        }
    }

    public void DecreaseLifeCount()
    {
        LifeCount -= 1;
        Hud.UpdateLifeCount(LifeCount);
        if(LifeCount == 0)
        {
            Hud.ShowGameOver();
        }
    }

    public void IncrementScore(int points)
    {
         Score += points;
         Hud.UpdateScore(Score);
    }
}
