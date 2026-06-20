using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
	public int Speed { get; set; } = 300;

	public Vector2 ScreenSize;

    public override void _Ready()
	{
		Velocity = new Vector2(-100, 200).Normalized() * Speed;
	}
    
    public override void _PhysicsProcess(double delta)
    {
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            GD.Print("COLLIDED");
            var reflect = collision.GetRemainder().Bounce(collision.GetNormal());
            Velocity = Velocity.Bounce(collision.GetNormal());
            MoveAndCollide(reflect);
        }
    }
}
