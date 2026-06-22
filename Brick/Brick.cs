using Godot;
using System;

public partial class Brick : Area2D
{
    int Points;
    
    public void OnBodyEntered(Node2D node)
    {
        if(node is Ball)
        {
            QueueFree();
        }
    } 
}