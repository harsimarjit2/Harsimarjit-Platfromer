using Godot;
using System;

public partial class Door : Area2D
{
    [Export] public string LevelFilePath;

    public void OnPlayerEntered(Node2D node)
    {
        if (node is Player)
            GetTree().ChangeSceneToFile(LevelFilePath);
    }
}
