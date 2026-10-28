using Godot;
using System;

public partial class EventBlock : Node2D
{
	[Export]
	Eventzone.EventType eventType = Eventzone.EventType.None;

	[Export]
	private float duration = 3.0f;

	[Export]
	private float strength = 1.0f;

	public override void _Ready()
	{
        GetNode<Eventzone>("Eventzone").eventType = eventType;
        GetNode<Eventzone>("Eventzone").duration = duration;
        GetNode<Eventzone>("Eventzone").strength = strength;
    }

}
