using Godot;
using System;

public partial class Hud : CanvasLayer
{
    Label GameOverLabel;
    Label ScoreLabel;
    Label LifeCountLabel;

    public override void _Ready()
    {
        GameOverLabel = GetNode<Label>("GameOverLabel");
        ScoreLabel = GetNode<Label>("ScoreLabel");
        LifeCountLabel = GetNode<Label>("LifeCountLabel");
        
        GameOverLabel.Hide();
    }

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
        ScoreLabel.Text = scoreString;
    }
    
    public void UpdateLifeCount(int lifeCount)
    {
        LifeCountLabel.Text = lifeCount.ToString();
    }

    public void ShowGameOver()
    {
        GameOverLabel.Show();
    }
}
