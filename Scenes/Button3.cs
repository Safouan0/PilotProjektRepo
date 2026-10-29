using Godot;
using System;

public partial class Button3 : Button
{

    public override void _Ready()
    {
        Pressed += QuitGame;
    }


    public void QuitGame()
    {
        GetTree().Quit();
    }

}
