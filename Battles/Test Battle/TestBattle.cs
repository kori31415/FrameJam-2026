using Godot;
using System;

public partial class TestBattle : Battle
{
	private const string battleFile = "res://Battles/Test Battle/TestBattle.tres";

	public TestBattle() : base(battleFile) { }
	
	protected override void addSkills() {
		AttackEffect attack = new AttackEffect();
		DefendEffect defend = new DefendEffect();

		skills = new System.Collections.Generic.Dictionary<string, Skill> {
			{ "Attack", attack },
			{ "Defend", defend }
		};
	}

}
