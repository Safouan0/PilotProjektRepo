using Godot;
using System;

public partial class StartButton : Button
{

    public override void _Ready()
    {
        Pressed += StartGame;
    }

    private void StartGame()
    {
        GetTree().ChangeSceneToFile("res://Scenes/level 9.tscn");
    }


}
