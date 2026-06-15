using Godot;
using System;

public partial class BattleTester : Node
{
	private Battle test;
	private BattleLoader testLoader;

	public override void _Ready() {
		testLoader = new BattleLoader("res://Scenes/BattleUI.tscn", "res://Battles/Test Battle/TestBattle.tres");
		test = new TestBattle();
		testLoader.LoadBattle(this, test);
	}
}
