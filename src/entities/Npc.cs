using Godot;
using System;

//NPCs assume being a child of a level, allowing to call the dialogue method of the level
public partial class Npc : Node2D
{
	[Export]
	public Dialogue NpcDialogue {get; private set;}
	
	public void TriggerDialogue()
	{
		GetParent<Level>().StartDialogue(NpcDialogue);
	}
}
