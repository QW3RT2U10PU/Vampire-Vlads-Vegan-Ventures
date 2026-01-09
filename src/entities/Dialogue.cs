using Godot;
using System;

[GlobalClass]
public partial class Dialogue : Resource
{
    [Export]
    Godot.Collections.Array<string> lines;
}
