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
        GDScript quizScript = GD.Load<GDScript>("res://Scripts/quiz.gd");
        quizScript.Set("score", 0);
        quizScript.Set("has_completed_quiz", false);
        Player.SetHasCompletedQuiz(true);
        GetTree().ChangeSceneToFile("res://Scenes/level 9.tscn");
    }


}
