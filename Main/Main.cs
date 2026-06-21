using Godot;

public partial class Main : Node
{
    int score = 0;

    private void UpdateScoreAfterHit(Node node, int incrementScoreBy)
    {
        if(node is Ball)
        {
            GD.Print("BLUEEEE");
            var hud = GetNode<Hud>("Hud");
            score+=1;
            hud.UpdateScore(score);
        }
    }
    public void OnBlueBrickHit(Node2D node)
    {
        UpdateScoreAfterHit(node, 1);
    }
}
