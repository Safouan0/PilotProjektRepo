using Godot;
using System;

public partial class LevitationEffect : AnimatedSprite2D
{
	

	private Player player;

	private bool wasLevitating;

	public override void _Ready()
	{
		player = GetParent<Player>();
		Hide();
		AnimationFinished += OnAnimationFinished;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (player.isLevitating == wasLevitating)
		{
			return;
		}

		wasLevitating = player.isLevitating;


		if(wasLevitating)
		{
            player.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Hide();
            Show();
			Play("start");
		}
		else
		{
			Play("end");
		}

	}

	public void OnAnimationFinished()
	{

		if (Animation == "start" && player.isLevitating)
		{
			Play("loop");
		}
        else if (Animation == "end" && !player.isLevitating)
        {
            player.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Show();
            Hide();
        }
    }

}
