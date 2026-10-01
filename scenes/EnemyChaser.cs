using Godot;

public partial class EnemyChaser : EnemyBat
{
	private Node2D Player;

	public override void _Ready()
	{
		base._Ready();

		Player = GetTree().GetFirstNodeInGroup("Player") as Node2D;

		if (Player == null)
		{
			GD.Print("PLAYER NOT FOUND!");
		}
	}

	protected override void EnemyBehavior()
	{
		if (Player == null)
			return;

		// Follow the player left and right
		if (Player.GlobalPosition.X > GlobalPosition.X)
		{
			Velocity = new Vector2(Speed, Velocity.Y);
		}
		else if (Player.GlobalPosition.X < GlobalPosition.X)
		{
			Velocity = new Vector2(-Speed, Velocity.Y);
		}
		else
		{
			Velocity = new Vector2(0, Velocity.Y);
		}

		MoveAndSlide();
	}
}
