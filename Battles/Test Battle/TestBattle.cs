using Godot;
using System;

public partial class TestBattle : Battle
{
	private const string name = "Test Battle";

	public TestBattle() : base(name) {
		skills = new System.Collections.Generic.Dictionary<string, Skill> {
			{ "Attack", new AttackEffect(name) },
			{ "Defend", new DefendEffect(name) }
		};

		enemies = new System.Collections.Generic.Dictionary<string, Enemy> {
			{ "Rat Enemy", new RatEnemy(name) }
		};
	}

	public override System.Collections.Generic.List<string> progressStory(System.Collections.Generic.List<Character> characters) {
		System.Collections.Generic.List<string> storyText = new System.Collections.Generic.List<string>();
		if (characters.Find(character => character.Name == "Gisela").Health <= 5) {
			storyText.Add("Story progress!");
		}
		return storyText;
	}

}
