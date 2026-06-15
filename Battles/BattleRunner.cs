using Godot;
using System;

public partial class BattleRunner : Node
{	
	public Battle battleParams;
	private BattleEngine engine;

	public BattleRunner() : this(null) {}

	public BattleRunner(Battle battleData) {
		battleParams = battleData;
		engine = new BattleEngine(battleParams);
	}

	public override void _Input(InputEvent input) {
		if (input is InputEventKey keyEvent && keyEvent.Pressed && !keyEvent.IsEcho()) {
				engine.doTheThing(keyEvent);
		}
	}
}
