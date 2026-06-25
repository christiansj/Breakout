using Godot;
using System;

public partial class Bricks : Node
{
	PackedScene BlueBrick = GD.Load<PackedScene>("res://Brick/BlueBrick.tscn");

	public override void _Ready()
	{
		GenerateBricks();
	}

	private void GenerateBricks()
	{
		HBoxContainer brickGrid = GetNode<HBoxContainer>("BrickGrid");
		brickGrid.OffsetRight = 250;
		Brick instance;
	
		for(int i = 0; i < 10; i++)
		{
			instance = (Brick)BlueBrick.Instantiate();
			instance.Points = 1;
			brickGrid.AddChild(instance);
			instance.Translate(new Vector2(80*i+1, 0));
		}
	}
}
