using Godot;
using System;
using System.Drawing;

public partial class Brick : Area2D
{
    private int _points = 0;
    private Main _main;

    public override void _Ready()
    {
        _main = GetNode<Main>("/root/Main/");
        base._Ready();
    }

    public void OnBodyEntered(Node2D node)
    {
        if(node is Ball)
        {
            QueueFree();
            IncrementGameScore();
            IncreaseBallVelocity();
            if (_main.IsBrickGridEmpty())
            {
                _main.HandleClearGrid();
            }
        }
    } 

    public void SetPoints(int points)
    {
        _points = points;
    }

    private void IncrementGameScore()
    {
        Main main = GetNode<Main>("/root/Main/");
        main.IncrementScore(_points);
    }

    private void IncreaseBallVelocity()
    {
        Ball ball = GetNode<Ball>("/root/Main/Ball/");
        if(_points == 5)
        {
            ball.IncreaseVelocity(1.025f);
        }
        else if (_points == 7)
        {
            ball.IncreaseVelocity(1.04f);
        }
    }
}