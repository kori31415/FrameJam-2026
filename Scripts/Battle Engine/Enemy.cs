using Godot;
using System;

public abstract partial class Enemy : Character
{

	public Enemy() : this("", "") {}
	public Enemy(string fileList, string nameInFileList) {
		Character characterData = GD.Load<Character>(BattleList.battles[fileList].enemies[nameInFileList]);
		Name = characterData.Name;
		Health = characterData.Health;
		SkillNames = characterData.SkillNames;
		IsPlayable = false;
	}

	public abstract Skill chooseSkill(System.Collections.Generic.List<Character> targets, System.Collections.Generic.List<Skill> options);
}
