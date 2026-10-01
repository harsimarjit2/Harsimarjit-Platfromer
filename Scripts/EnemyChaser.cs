using Godot;

public partial class EnemyChaser : EnemyBat
{
	private bool canSeePlayer = false;
	private Node2D player = null;


	public override void _Process(double delta)
	{
		if (canSeePlayer)
		{
			var distance = player.GlobalPosition- this.GlobalPosition;
			
			Velocity = distance.Normalized() * Speed;


			MoveAndSlide();
		}
		else
		{
			Velocity = Vector2.Zero;
		}
	}

	public void PlayerEnters(Node2D body)
	{
		if (body is Player)
		{
			canSeePlayer = true;
			player = body;
		}
	}

	public void PlayerExits(Node2D body)
	{
		if (body is Player)
		{
			canSeePlayer = false;
			player = null;
		}
	}
	
}
