using Godot;
using System;

public partial class Button2 : Button
{
	public override void _Ready()
	{
        Pressed += ChangeDifficulty;

    }

	
	
	public void ChangeDifficulty()
	{
		if (Player.GravityMultiplier == 1.0f)
		{

			//GD.Load<CSharpScript>("res://Scripts/Player.cs").Set("GravityMultiplier", 0.85f);
            Player.GravityMultiplier = 0.85f;
            Text = "Easy Mode";
		}
		else
		{
            //GD.Load<CSharpScript>("res://Scripts/Player.cs").Set("GravityMultiplier", 1.0f);
			Player.GravityMultiplier = 1.0f;

            Text = "Normal Mode";
        }
		

	}


}
