using Godot;
using System;

public abstract partial class Skill : SkillData
{
	protected string storageLocation { get; set; }
	public Character target { get; set; }
	public System.Collections.Generic.Dictionary<string, int> customNumbers { get; set; }

	public Skill() : this("", "") {}
	public Skill(string fileList, string nameInFileList) {
		storageLocation = fileList;
		SkillData skillData = GD.Load<SkillData>(BattleList.battles[fileList].skills[nameInFileList]);
		Name = skillData.Name;
		Description = skillData.Description;
		BeginningText = skillData.BeginningText;
		EndingText = skillData.EndingText;
		ValidTargets = skillData.ValidTargets;
	}

	public abstract void enactAction(int echo);
	public abstract Skill clone();
}
