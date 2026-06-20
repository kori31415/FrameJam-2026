using Godot;
using System;

public abstract partial class Battle : BattleData
{
	public System.Collections.Generic.Dictionary<string, Enemy> enemies;
	protected System.Collections.Generic.Dictionary<string, Skill> skills;
	protected BattleFilepathList battleFiles;

	public Battle() : this("") {}
	public Battle(string name) {
		BattleData battleData = GD.Load<BattleData>(BattleList.battles[name].battle);
		BattleName = battleData.BattleName;
		CharacterNames = battleData.CharacterNames;
	}

	public Skill getSkillByName(string skillName) {
		return skills[skillName];
	}

	public abstract System.Collections.Generic.List<string>  progressStory(System.Collections.Generic.List<Character> characters);
}
