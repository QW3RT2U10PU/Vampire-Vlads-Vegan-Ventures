using Godot;
using System;

public partial class NPCText : PanelContainer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(double delta)
    // {
    //     base._Process(delta);
    // }

    public override void _Input(InputEvent @event)
    {
		if (@event.IsActionPressed("ui_accept"))
		{
			// next dialogue
		}
    }
}
