using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
	public float Speed { get; set; } = 350;
    public Boolean IsFollowing {get; set;} = true;
	public Vector2 ScreenSize;
    Main main;
    
    public override void _Ready()
	{
        main = GetNode<Main>("/root/Main");
        IsFollowing = true;
	}
    
    public void Serve()
    {
        Velocity = new Vector2(-130, 200).Normalized() * Speed;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        
        if(Input.IsActionJustPressed("click") && IsFollowing && main.LifeCount > 0)
        {
            Serve();
            IsFollowing = false;
        }

        if(IsFollowing)
        {
            Paddle paddle = GetNode<Paddle>("../Paddle");
            SetPosition(new Vector2(paddle.Position.X + 60, paddle.Position.Y - 25));
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            var reflect = collision.GetRemainder().Bounce(collision.GetNormal());
            Velocity = Velocity.Bounce(collision.GetNormal());
            MoveAndCollide(reflect);
        }
    }

    public void IncreaseVelocity(float multiplier)
    {
        Velocity *= multiplier;
    }
}
