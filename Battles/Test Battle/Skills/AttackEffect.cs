using Godot;
using System;

public partial class AttackEffect : Skill {
	
    const string skillFile = "res://Battles/Test Battle/Skills/AttackData.tres";
    public AttackEffect() : base(skillFile) {}
	
	public override void enactAction(int echo) {
		target.Health -= 5;
	}
}
