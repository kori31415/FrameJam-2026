using Godot;
using System;

[GlobalClass]
public partial class SkillData : Resource {
	
	[Export]
	public string Name { get; set; }
	
	[Export]
	public string Description { get; set; }
	
	[Export]
	public string BeginningText { get; set; }
	
	[Export]
	public string EndingText { get; set; }	

	[Export]
	public string ValidTargets { get; set; }

	public SkillData() : this("", "", "", "") {}

	public SkillData(string name, string description, 
		string beginningText, string endingText) {
		Name = name;
		Description = description;
		BeginningText = beginningText;
		EndingText = endingText;
	}

}
