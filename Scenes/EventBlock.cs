using Godot;
using System;

public partial class EventBlock : Node2D
{
	[Export]
	Eventzone.EventType eventType = Eventzone.EventType.None;

	[Export]
	private int duration = 3;

	[Export]
	private int strength = 1;

	public override void _Ready()
	{
		GetNode<Eventzone>("Eventzone").eventType = eventType;
		GetNode<Eventzone>("Eventzone").duration = duration;
		GetNode<Eventzone>("Eventzone").strength = strength;
	}

}
