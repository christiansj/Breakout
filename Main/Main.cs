using Godot;

public partial class Main : Node2D
{
    int Score = 0;
    int LifeCount = 3;
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

    private void UpdateScoreAfterHit(Node node, int incrementScoreBy)
    {
        if(node is Ball)
        {
            Score += incrementScoreBy;
            Hud.UpdateScore(Score);
        }
    }

    
    public void OnBlueBrickHit(Node2D node)
    {
        UpdateScoreAfterHit(node, 1);
    }

    public void OnGreenBrickHit(Node2D node)
    {
        UpdateScoreAfterHit(node, 1);
    }
}
