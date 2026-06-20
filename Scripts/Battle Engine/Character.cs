using Godot;
using System;

[GlobalClass]
public partial class Character : Resource {
	[Export]
	public string Name { get; set; }
	
	[Export]
	public int Health  { get; set; }

	[Export]
	public bool IsPlayable { get; set; }
	
	[Export]
	public string[] SkillNames  { get; set; }

	
	public Character() : this(0, "", []) {}
	
	public Character(int health, string name, string[] skillNames) {
		Health = health;
		Name = name;
		SkillNames = skillNames;
	}
	
}
