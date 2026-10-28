using Godot;
using System;

public partial class Eventzone : Area2D
{

    public enum EventType
    {
        None, Levitate
    }


    [Export]
    public EventType eventType = EventType.None;

    [Export]
    public float strength = 1.0f;

    [Export]
    public float duration = 3.0f;

    private Player player;
    private Timer timer;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
        timer = GetNode<Timer>("Timer");
        timer.Timeout += onTimerTimeout;

    }


    public void OnBodyEntered(Node2D body)
    {
        
        player = (Player)body;


        switch (eventType)
        {
            case EventType.None:
                break;

            case EventType.Levitate:
                levitate();
                break;

            default:
                break;

        }
        


    }

    public void onTimerTimeout()
    {

        switch (eventType)
        {

            case EventType.None:
                break;

            case EventType.Levitate:
                player.isLevitating = false;
                break;

            default:
                break;

        }

    }

    public void levitate()
    {
        player.levitationStrength = strength;
        player.isLevitating = true;
        timer.Start(duration);
    }


}
