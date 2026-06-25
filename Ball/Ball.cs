using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
	public int Speed { get; set; } = 350;

	public Vector2 ScreenSize;

    public override void _Ready()
	{
		Velocity = new Vector2(-150, 150).Normalized() * Speed;
	}
    
    public void Serve()
    {
        SetPosition(new Vector2(450, 360));
    }

    public override void _PhysicsProcess(double delta)
    {
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            if(collision.GetCollider().GetClass() == "CharacterBody2D")
            {
                float paddleX = (collision.GetCollider() as Node2D).Position.X;
                float collisionX = collision.GetPosition().X;
            
                if(collisionX > paddleX+60)
                {
                    if(Velocity.X < 0)
                    {
                        Velocity *= -1;
                    }
                }
                else
                {
                    if(Velocity.X > 0)
                    {
                        Velocity *= -1;
                    }
                }
            }
            
            var reflect = collision.GetRemainder().Bounce(collision.GetNormal());
            Velocity = Velocity.Bounce(collision.GetNormal());
            // MoveAndCollide(reflect);
        }
    }
}
