using Godot;
using System;

public partial class DefendEffect : Skill {
	
	const string skillFile = "res://Battles/Test Battle/Skills/DefendData.tres";
    public DefendEffect() : base(skillFile) {}

	public override void enactAction(int echo) {
		target.Health += 2;
	}
}
