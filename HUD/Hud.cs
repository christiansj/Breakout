using Godot;
using System;

public partial class Hud : CanvasLayer
{
    public void UpdateScore(int score)
    {
        String scoreString;
        if(score < 100 && score > 9)
        {
            scoreString = "0" + score.ToString();
        }
        else if(score < 10)
        {
            scoreString = "00" + score.ToString();
        }
        else
        {
            scoreString = score.ToString();
        }
        GetNode<Label>("ScoreLabel").Text = scoreString;
    }
}
