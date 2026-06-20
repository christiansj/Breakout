using Godot;
using System;

public partial class Paddle : CharacterBody2D
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
   

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(
			x: Mathf.Clamp(GetViewport().GetMousePosition().X -50, 0, ScreenSize.X - 120),
			y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)	
		);
	}
}
