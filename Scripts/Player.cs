using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -800.0f;

	private AnimatedSprite2D animatedSprite;
	private AudioStreamPlayer2D jumpSound;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		jumpSound = GetNode<AudioStreamPlayer2D>("JumpSound");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

			 
		// Add animation
		if (!IsOnFloor())
		{
			animatedSprite.Animation = "Jumping";

		}
		else if (velocity.X > 0 || velocity.X < 0)
		{
			animatedSprite.Animation = "Walk";
		}
		else
		{
			animatedSprite.Animation = "Side idle";
		}



		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			jumpSound.Play();
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("left", "right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();

		if (direction.X == 1)
		{
			animatedSprite.FlipH = false;
		} else if (direction.X == -1)
		{
			animatedSprite.FlipH = true;
		}

	}
}
