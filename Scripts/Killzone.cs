using Godot;
using System;

public partial class Killzone : Area2D
{

    private Timer timer;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        timer = GetNode<Timer>("Timer");
        timer.Timeout += OnTimerTimeout;
    }

    public void OnBodyEntered(Node2D body)
    {
        GD.Print("You died!");
        GD.Print($"Killzone registrerede: {body.Name}");
        timer.Start();
    }

    public void OnTimerTimeout()
    {
        GetTree().ReloadCurrentScene();
    }

}
