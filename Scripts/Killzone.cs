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

		//Cast body as player
		((Player)body).isDead = true;
		((Player)body).Velocity = new Vector2(GD.RandRange(-150, 150), -200);

		Engine.TimeScale = 0.5;
		body.GetNode("CollisionShape2D").QueueFree();

		//Create a tween (stems form in-between). One for camera zoom and one for rotating the spride
		CreateTween().TweenProperty(body.GetNode<Camera2D>("Camera2D"), "zoom", new Vector2(4f, 4f), 0.5);
		CreateTween().TweenProperty(body.GetNode<AnimatedSprite2D>("AnimatedSprite2D"), "rotation_degrees", body.GetNode<AnimatedSprite2D>("AnimatedSprite2D").RotationDegrees + 720 * ((GD.RandRange(0, 1) * 2 - 1)), 5);


		body.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Animation = "Death";
		body.GetNode<AudioStreamPlayer2D>("DeathSound").Play();

		timer.Start();
		

	}

	public void OnTimerTimeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
	}

}
