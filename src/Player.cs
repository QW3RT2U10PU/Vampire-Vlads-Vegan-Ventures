using System;

namespace GameJam;

using Godot;

public partial class Player : CharacterBody2D
{
	public static PackedScene Scene { get; } = GD.Load<PackedScene>("uid://l5ejvbu0pwmb");

	[Export] public float Speed { get; set; } = 300.0f;

	[Export] public float AirDrag { get; set; } = 1.7f;

	[Export] public float DashSpeed { get; set; } = 5f;

	[Export] public float JumpStrength { get; set; } = 400.0f;

	[Flags]
	private enum DashState
	{
		Active = 4,
		Cooldown = 1,
		NeedsFloor = 2
	}

	private DashState _dashState = 0;

	public override void _PhysicsProcess(double delta)
	{
		Timer dashTimer = GetNode<Timer>("dashTimer");
		Timer dashCooldown = GetNode<Timer>("dashCooldown");
		Vector2 velocity = Velocity;

		// Add the gravity.
		Vector2 direction = Input.GetVector("move_left", "move_right", "jump", "ui_graph_follow_left");
		velocity.X = direction.X * Speed;

		if (Input.IsActionJustPressed("dash") && _dashState == 0)
		{
			dashTimer.Start();
			dashCooldown.Start();
			_dashState = DashState.Active;
		}

		if (_dashState == DashState.Active)
		{
			velocity.X *= DashSpeed;
		}

		if (IsOnFloor())
		{
			if (_dashState != DashState.Active) _dashState &= ~DashState.NeedsFloor;
		}
		else if (_dashState != DashState.Active)
		{
			velocity += GetGravity() * (float)delta;
			velocity.X /= AirDrag;
		}
		else
		{
			velocity.Y = 0;
		}

		if (direction.Y < 0 && IsOnFloor())
		{
			velocity.Y = -JumpStrength;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void DashExpired()
	{
		_dashState = DashState.Cooldown | DashState.NeedsFloor;
	}

	public void DashCooldownExpired()
	{
		_dashState &= ~DashState.Cooldown;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("interact"))
		{
			GetViewport().SetInputAsHandled();
			Interactable.FocusedInteractable?.Interact(Interactable.FocusedInteractableBody);
		}
	}
}
