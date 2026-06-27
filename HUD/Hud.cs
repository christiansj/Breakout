using Godot;
using System;

public partial class Hud : CanvasLayer
{
    private Label _gameOverLabel;
    private Label _scoreLabel;
    private Label _lifeCountLabel;

    public override void _Ready()
    {
        _gameOverLabel = GetNode<Label>("GameOverLabel");
        _scoreLabel = GetNode<Label>("ScoreLabel");
        _lifeCountLabel = GetNode<Label>("LifeCountLabel");
        
        _gameOverLabel.Hide();
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
        _scoreLabel.Text = scoreString;
    }
    
    public void UpdateLifeCount(int lifeCount)
    {
        _lifeCountLabel.Text = lifeCount.ToString();
    }

    public void ShowGameOver()
    {
        _gameOverLabel.Show();
    }
}
