using Godot;
using System;

public partial class BrickGrid : Node
{
	private PackedScene _yellowBrick = GD.Load<PackedScene>("res://Brick/YellowBrick.tscn");
	private PackedScene _greenBrick = GD.Load<PackedScene>("res://Brick/GreenBrick.tscn");
	private PackedScene _orangeBrick = GD.Load<PackedScene>("res://Brick/OrangeBrick.tscn");
	private PackedScene _redBrick = GD.Load<PackedScene>("res://Brick/RedBrick.tscn");
	private BoxContainer _container;

	public override void _Ready()
	{
		GenerateBricks();
	}

	public void GenerateBricks()
	{
		_container = GetNode<BoxContainer>("Container");
		_container.OffsetRight = 250;
		
		for(int row = 0; row < 8; row++)
		{
			for(int iBrick = 0; iBrick < 10; iBrick++)
			{
				Brick brick = GetBrick(row);
				_container.AddChild(brick);
				brick.Translate(new Vector2(80*iBrick+1, 25*row));
			}
		}
	}

	private Brick GetBrick(int row)
	{
		Brick brick;
		if(row >= 6 && row < 8)
		{
			brick = (Brick)_yellowBrick.Instantiate();
			brick.SetPoints(1);
		}
		else if(row >= 4 && row < 6)
		{
			brick = (Brick)_greenBrick.Instantiate();
			brick.SetPoints(3);
		}
		else if(row >= 2 && row < 4)
		{
			brick = (Brick)_orangeBrick.Instantiate();
			brick.SetPoints(5);
		}
		else
		{
			brick = (Brick)_redBrick.Instantiate();
			brick.SetPoints(7);
		}
		return brick;
	}

	public bool IsGridEmpty()
	{
		GD.Print(_container.GetChildCount());
		return _container.GetChildCount() == 1;
	}
}
