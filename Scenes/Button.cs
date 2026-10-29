using Godot;
using System;

public partial class Button : Godot.Button
{



    public override void _Ready()
    {
        Pressed += OpenMenu;

    }

    private void OpenMenu()
    {
        GetTree().ChangeSceneToFile("res://Scenes/StartScene.tscn");
    }
}
