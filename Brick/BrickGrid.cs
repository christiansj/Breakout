using Godot;
using System;

public partial class BrickGrid : Node
{
	PackedScene YellowBrick = GD.Load<PackedScene>("res://Brick/YellowBrick.tscn");
	PackedScene GreenBrick = GD.Load<PackedScene>("res://Brick/GreenBrick.tscn");
	PackedScene OrangeBrick = GD.Load<PackedScene>("res://Brick/OrangeBrick.tscn");
	PackedScene RedBrick = GD.Load<PackedScene>("res://Brick/RedBrick.tscn");
	public override void _Ready()
	{
		GenerateBricks();
	}

	private void GenerateBricks()
	{
		BoxContainer container = GetNode<BoxContainer>("Container");
		container.OffsetRight = 250;
		
		for(int row = 0; row < 8; row++)
		{
			for(int iBrick = 0; iBrick < 10; iBrick++)
			{
				Brick brick = GetBrick(row);
				container.AddChild(brick);
				brick.Translate(new Vector2(80*iBrick+1, 25*row));
			}
		}
	}

	private Brick GetBrick(int row)
	{
		Brick brick;
		if(row >= 6 && row < 8)
		{
			brick = (Brick)YellowBrick.Instantiate();
			brick.Points = 1;
		}
		else if(row >= 4 && row < 6)
		{
			brick = (Brick)GreenBrick.Instantiate();
			brick.Points = 3;
		}
		else if(row >= 2 && row < 4)
		{
			brick = (Brick)OrangeBrick.Instantiate();
			brick.Points = 5;
		}
		else
		{
			brick = (Brick)RedBrick.Instantiate();
			brick.Points = 7;
		}
		return brick;
	}
}
