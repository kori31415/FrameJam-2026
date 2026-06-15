using Godot;
using System;

public abstract partial class Battle : BattleData
{
    protected System.Collections.Generic.Dictionary<string, Skill> skills;

    public Battle() : this("") {}

    public Battle(string battleFile) {
        BattleData battleData = GD.Load<BattleData>(battleFile);
		BattleName = battleData.BattleName;
		CharacterNames = battleData.CharacterNames;
		CharacterFiles = battleData.CharacterFiles;
        addSkills();
    }

    public Skill getSkillByName(string skillName) {
        return skills[skillName];
    }

    protected abstract void addSkills();
}


