using Godot;
using System;

public partial class EnemyBat : CharacterBody2D
{
	public const float Speed = 150.0f;

	protected bool IsFacingRight = true;

	protected RayCast2D GroundRay;

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

		// Move
		if (IsFacingRight)
		{
			velocity.X = Speed;
		}
		else
		{
			velocity.X = -Speed;
		}

		// Check if there is ground
		if (!GroundRay.IsColliding())
		{
			TurnAround();
		}

		Velocity = velocity;
		MoveAndSlide();

		// Polymorphism
		EnemyBehavior();
	}

	// Allows child enemies to have different behaviors
	protected virtual void EnemyBehavior()
	{
		// Base enemy behavior
	}

	protected void TurnAround()
	{
		IsFacingRight = !IsFacingRight;

		AnimatedSprite2D sprite =
			GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		sprite.FlipH = !IsFacingRight;

		GroundRay.TargetPosition = new Vector2(
			-GroundRay.TargetPosition.X,
			GroundRay.TargetPosition.Y
		);
	}
}
