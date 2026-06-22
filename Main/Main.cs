using Godot;

public partial class Main : Node
{
    int Score = 0;

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
