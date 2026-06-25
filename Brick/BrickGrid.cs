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
		BoxContainer row1 = GetNode<BoxContainer>("Container");
		row1.OffsetRight = 250;
		Brick instance;

		// Red Bricks
		for(int row = 0; row < 2; row++)
		{
			for(int iBrick = 0; iBrick < 10; iBrick++)
			{
				instance = (Brick)RedBrick.Instantiate();
				instance.Points = 7;
				row1.AddChild(instance);
				instance.Translate(new Vector2(80*iBrick+1, 25*row));
			}
		}

		// Orange Bricks
		for(int row = 2; row < 4; row++)
		{
			for(int iBrick = 0; iBrick < 10; iBrick++)
			{
				instance = (Brick)OrangeBrick.Instantiate();
				instance.Points = 5;
				row1.AddChild(instance);
				instance.Translate(new Vector2(80*iBrick+1, 25*row));
			}
		}

		

		// Green Bricks
		for(int row = 4; row < 6; row++)
		{
			for(int iBrick = 0; iBrick < 10; iBrick++)
			{
				instance = (Brick)GreenBrick.Instantiate();
				instance.Points = 3;
				row1.AddChild(instance);
				instance.Translate(new Vector2(80*iBrick+1, 25*row));
			}
		}

		for(int row = 6; row < 8; row++)
		{
			for(int iBrick = 0; iBrick < 10; iBrick++)
			{
				instance = (Brick)YellowBrick.Instantiate();
				instance.Points = 1;
				row1.AddChild(instance);
				instance.Translate(new Vector2(80*iBrick+1, 25*row));
			}
		}
	
		
		// BoxContainer row2 = GetNode<BoxContainer>("Row1");
		// row2.OffsetRight = 250;
		// for(int i = 0; i < 10; i++)
		// {
		// 	instance = (Brick)YellowBrick.Instantiate();
		// 	instance.Points = 1;
		// 	row2.AddChild(instance);
		// 	instance.Translate(new Vector2(80*i+1, 25));
		// }
	}
}
