using Godot;
using System;

public partial class EnemyBat : CharacterBody2D
{
    public const float Speed = 150.0f;

    private bool IsFacingRight = true;

    private RayCast2D GroundRay;

    public override void _Ready()
    {
        GroundRay = GetNode<RayCast2D>("RayCast2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Gravity
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Move to the right
        if (IsFacingRight)
        {
            velocity.X = Speed;
        }
        else
        {
            velocity.X = -Speed;
        }

        // Check if there is ground in front of the enemy
        if (!GroundRay.IsColliding())
        {
            TurnAround();
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void TurnAround()
    {
        // Change direction
        IsFacingRight = !IsFacingRight;

        // Flip the sprite
        AnimatedSprite2D sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        sprite.FlipH = !IsFacingRight;

        // Flip the RayCast2D
        GroundRay.TargetPosition = new Vector2(
            -GroundRay.TargetPosition.X,
            GroundRay.TargetPosition.Y
        );
    }
}