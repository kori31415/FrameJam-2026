using Godot;
using System;

public abstract partial class BattleFilepathList : Node
{

	public string battle { get; set; }
	public System.Collections.Generic.Dictionary<string, string> playerCharacters { get; set; }
	public System.Collections.Generic.Dictionary<string, string> enemies { get; set; }
	public System.Collections.Generic.Dictionary<string, string> skills { get; set; }

	public BattleFilepathList() {}
}
