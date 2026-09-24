using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -425.0f;

    private AnimatedSprite2D _animatedSprite;

    public override void _Ready()
    {
        // Fetches your sprite node when the game starts
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        
        
        if (direction.X > 0)
        {
            _animatedSprite.FlipH = false;
        }
        else if (direction.X < 0)
        {
            _animatedSprite.FlipH = true;
        }

        
        if (IsOnFloor())
        {
            if (direction.X == 0)
            {
                _animatedSprite.Play("idle"); 
            }
            else
            {
                _animatedSprite.Play("Run");  
            }
        }
        else
        {
            _animatedSprite.Play("Jump");    
        }

        // --- APPLY MOVEMENT ---
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}