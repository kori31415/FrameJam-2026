using Godot;
using System;

public partial class DefendEffect : Skill {
	

	public DefendEffect() {}
	public DefendEffect(string storage) : base(storage, "Defend") {
		customNumbers = new System.Collections.Generic.Dictionary<string, int> {
			{ "Damage", 2 }
		};
	}

	public override void enactAction(int echo) {
		target.Health += customNumbers["Damage"];
	}
	
	public override Skill clone(){
		return new DefendEffect(this.storageLocation);
	}
}
