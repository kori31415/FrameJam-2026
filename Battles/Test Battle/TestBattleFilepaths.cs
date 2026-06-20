using Godot;
using System;

public partial class TestBattleFilepaths : BattleFilepathList
{
	public TestBattleFilepaths() {
		battle = "res://Battles/Test Battle/TestBattle.tres";

		playerCharacters = new System.Collections.Generic.Dictionary<string, string> {
			{ "Gisela", "res://Battles/Test Battle/Characters/Gisela.tres" },
			{ "Rat Friend", "res://Battles/Test Battle/Characters/Rat Friend.tres" },
		};
		
		enemies = new System.Collections.Generic.Dictionary<string, string> {
			{ "Rat Enemy", "res://Battles/Test Battle/Characters/Enemies/Rat Enemy.tres" }
		};

		skills = new System.Collections.Generic.Dictionary<string, string> {
			{ "Attack", "res://Battles/Test Battle/Skills/AttackData.tres" },
			{ "Defend", "res://Battles/Test Battle/Skills/DefendData.tres" }
		};
	}
}
