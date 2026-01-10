using Godot;
using System;

public partial class Pausemenu : HBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _Input(InputEvent @event)
    {
		if (@event.IsActionPressed("pause"))
		{
			GetViewport().SetInputAsHandled();
			GetTree().Paused = !GetTree().Paused;
			if (GetTree().Paused)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}
	}

	public void ContinueGame()
	{
		Hide();
		GetTree().Paused = false;
	}
	public void GoToMainMenu()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("uid://difj88kcjy8k3");
	}
	public void QuitGame()
	{
		GetTree().Paused = false;
		GetTree().Quit();
	}
}
