using Godot;
using System;

public partial class AttackEffect : Skill {
	
	public AttackEffect() : this("") {}
	public AttackEffect(string storage) : base(storage, "Attack") {
		customNumbers = new System.Collections.Generic.Dictionary<string, int> {
			{ "Damage", 5 }
		};
	}
	
	public override void enactAction(int echo) {
		target.Health -= customNumbers["Damage"];
	}
	
	public override Skill clone(){
		return new AttackEffect(this.storageLocation);
	}
}
