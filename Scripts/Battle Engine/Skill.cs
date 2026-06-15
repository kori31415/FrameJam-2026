using Godot;
using System;

public abstract partial class Skill : SkillData
{
	public Character target { get; set; }

	public Skill(string skillFile) {
        SkillData skillData = GD.Load<SkillData>(skillFile);
		Name = skillData.Name;
		Description = skillData.Description;
		BeginningText = skillData.BeginningText;
		EndingText = skillData.EndingText;
	}

	public abstract void enactAction(int echo);
}
