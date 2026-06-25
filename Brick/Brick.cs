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
            Main main = GetNode<Main>("/root/Main/");
            main.IncrementScore(Points);
        }
    } 
}