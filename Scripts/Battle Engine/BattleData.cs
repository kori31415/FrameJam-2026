using Godot;
using System;

[GlobalClass]
public partial class BattleData : Resource
{	
	[Export]
	public string BattleName;

	[Export]
	public string[] CharacterNames { get; set; } 
	
	[Export]
	public string[] CharacterFiles { get; set; }
	
	public BattleData() : this("", [], []) {}
	
	public BattleData(string battleName, string[] characterNames, string[] characterFiles) {
		BattleName = battleName;
		CharacterNames = characterNames;
		CharacterFiles = characterFiles;
	}
}
