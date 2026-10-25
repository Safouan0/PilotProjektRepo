using Godot;
using System;

public partial class Winzone : Area2D
{

    private Timer timer;

    [Export]
    public string NextScene = "";

    public override void _Ready()
    {   

        BodyEntered += OnBodyEntered;
        timer = GetNode<Timer>("Timer");
        timer.Timeout += OnTimerTimeout;

    }

    public void OnBodyEntered(Node2D body)
    {


        GD.Print("Level completed!");

        timer.Start();


    }


    public void OnTimerTimeout()
    {

       
        GetTree().ChangeSceneToFile(NextScene);

    }


}
