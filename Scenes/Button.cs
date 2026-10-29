using Godot;
using System;

public partial class Button : Godot.Button
{



    public override void _Ready()
    {


        switch (GetTree().CurrentScene.SceneFilePath)
        {
            case "res://Scenes/level 9.tscn":

                ((StyleBoxTexture)GetThemeStylebox("pressed")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 9 Knap (Clicked).png");
                ((StyleBoxTexture)GetThemeStylebox("hover")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 9 Knap (Hover).png");
                ((StyleBoxTexture)GetThemeStylebox("normal")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 9 Knap (Normal).png");

                break;

            case "res://Scenes/level 7.tscn":

                ((StyleBoxTexture)GetThemeStylebox("pressed")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 7 Knap (Clicked).png");
                ((StyleBoxTexture)GetThemeStylebox("hover")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 7 Knap (Hover).png");
                ((StyleBoxTexture)GetThemeStylebox("normal")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 7 Knap (Normal).png");


                break;

            case "res://Scenes/level 2.tscn":

                ((StyleBoxTexture)GetThemeStylebox("pressed")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 2 Knap (Clicked).png");
                ((StyleBoxTexture)GetThemeStylebox("hover")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 2 Knap (Hover).png");
                ((StyleBoxTexture)GetThemeStylebox("normal")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Lvl 2 Knap (Normal).png");

                break;

            default:

                ((StyleBoxTexture)GetThemeStylebox("pressed")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Base Knap (Clicked).png");
                ((StyleBoxTexture)GetThemeStylebox("hover")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Base Knap (Hover).png");
                ((StyleBoxTexture)GetThemeStylebox("normal")).Texture = GD.Load<Texture2D>("res://Assets/Sprites/Knapper/Base Knap (Normal).png");

                break;
        }


        
        Pressed += OpenMenu;


    }

    private void OpenMenu()
    {
        GetTree().ChangeSceneToFile("res://Scenes/StartScene.tscn");
    }
}
