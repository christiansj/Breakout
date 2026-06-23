using Godot;

public partial class Main : Node2D
{
    int Score = 0;
    int LifeCount = 3;
    public Vector2 ScreenSize;

    public override void _Ready()
    {
        var hud = GetNode<Hud>("Hud");
        hud.UpdateLifeCount(LifeCount);
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
        var hud = GetNode<Hud>("Hud");
        hud.UpdateLifeCount(LifeCount);
        if(LifeCount == 0)
        {
            hud.ShowGameOver();
        }
    }

    private void UpdateScoreAfterHit(Node node, int incrementScoreBy)
    {
        if(node is Ball)
        {
            var hud = GetNode<Hud>("Hud");
            Score += incrementScoreBy;
            hud.UpdateScore(Score);
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
