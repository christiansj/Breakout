using Godot;
using System;

public partial class Paddle : Area2D
{
	[Export]
	public int Speed {get; set; } = 400;

	public Vector2 ScreenSize;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		GD.Print(ScreenSize);
	}
	private void OnBodyEntered(Node2D body)
    {
        
	
    }
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if(Input.IsActionPressed("move_right"))
		{
			velocity.X += 1;
		}

		if(Input.IsActionPressed("move_left"))
		{
			velocity.X -= 1;
		}

		if(velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}

		Position += velocity * (float)delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.X, 0, ScreenSize.X - 100),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)	
		);
	}
}
