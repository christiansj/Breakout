using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Export]
	public float Speed { get; set; } = 350;
    public Boolean IsFollowing {get; set;} = true;
	public Vector2 ScreenSize;
    private const int MIN_VELOCITY = 140;
    private const int MAX_VELOCITY = 620;
    Main main;
    
    public override void _Ready()
	{
        main = GetNode<Main>("/root/Main");
        IsFollowing = true;
	}
    
    public void Serve()
    {
        Velocity = new Vector2(-350, 450).Normalized() * Speed;
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
            SetPosition(new Vector2(paddle.Position.X + 50, paddle.Position.Y - 25));
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
        SetMinimumVelocity();
        SetMaximumVelocity();
    }
    
    private void SetMinimumVelocity()
    {
        if(Velocity.Y <= 0 && Velocity.Y >= -MIN_VELOCITY)
        {
            SetVelocity(new Vector2(Velocity.X, -MIN_VELOCITY));
        } 
        if(Velocity.Y >= 0 && Velocity.Y <= MIN_VELOCITY)
        {
            SetVelocity(new Vector2(Velocity.X, MIN_VELOCITY));
        }

        if(Velocity.X <= 0 && Velocity.X >= -MIN_VELOCITY)
        {
            SetVelocity(new Vector2(-MIN_VELOCITY, Velocity.Y));
        } 
        if(Velocity.X >= 0 && Velocity.X <= MIN_VELOCITY)
        {
            SetVelocity(new Vector2(MIN_VELOCITY, Velocity.Y));
        }
    }

    private void SetMaximumVelocity()
    {
        if(Velocity.Y < -MAX_VELOCITY)
        {
            SetVelocity(new Vector2(Velocity.X, -MAX_VELOCITY));
        }
        if(Velocity.Y > MAX_VELOCITY)
        {
            SetVelocity(new Vector2(Velocity.X, MAX_VELOCITY));
        }
        if(Velocity.X < -MAX_VELOCITY)
        {
           SetVelocity(new Vector2(-MAX_VELOCITY, Velocity.Y));
        }
        if(Velocity.X > MAX_VELOCITY)
        {
            SetVelocity(new Vector2(MAX_VELOCITY, Velocity.Y));
        }
    }

    public void IncreaseVelocity(float multiplier)
    {
        Velocity *= multiplier;
    }
}
