using Godot;
using System;

public partial class MainMenu : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_Start_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Player.tscn");
	}


	private void _on_Exit_pressed()
	{
		GetTree().Quit();
	}
}