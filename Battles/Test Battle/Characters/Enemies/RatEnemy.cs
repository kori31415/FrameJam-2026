using Godot;
using System;

public partial class RatEnemy : Enemy
{
	public RatEnemy() {}
	public RatEnemy(string storage) : base(storage, "Rat Enemy") {}
	public override Skill chooseSkill(System.Collections.Generic.List<Character> targets, 
		System.Collections.Generic.List<Skill> options) {
		
		Skill chosen = options.Find(skill => skill.Name == "Attack").clone();
		chosen.target = targets.Find(character => character.Name == "Gisela");
		return chosen;
	}
}
