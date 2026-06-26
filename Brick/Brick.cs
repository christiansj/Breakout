using Godot;
using System;

public partial class Brick : Area2D
{
    public int Points = 0;

    public void OnBodyEntered(Node2D node)
    {
        if(node is Ball)
        {
            QueueFree();
            IncrementGameScore();
            IncreaseBallVelocity();
        }
    } 

    private void IncrementGameScore()
    {
        Main main = GetNode<Main>("/root/Main/");
        main.IncrementScore(Points);
    }

    private void IncreaseBallVelocity()
    {
        Ball ball = GetNode<Ball>("/root/Main/Ball/");
        if(Points == 3)
        {
            ball.IncreaseVelocity(1.025f);
        }
        else if (Points > 3)
        {
            ball.IncreaseVelocity(1.04f);
        }
    }
}