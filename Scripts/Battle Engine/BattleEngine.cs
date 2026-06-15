using Godot;
using System;

public partial class BattleEngine: Node {
	
	const int maxQueueLength = 3;

	public Battle battle;
	public System.Collections.Generic.List<Character> characters;
	public System.Collections.Generic.List<System.Collections.Generic.List<Skill>> skills;
	public System.Collections.Generic.List<System.Collections.Generic.List<Skill>> queues;

	private int characterIndex;
	private int skillIndex;
	private int targetIndex;
	private string text;
	private string phase;
	private Skill currentSkill;

	int i;

	public BattleEngine(Battle newBattle) {
		phase = "Player";
		battle = newBattle;
		
		populateCharacters();
		populateSkills();

		queues = new System.Collections.Generic.List<System.Collections.Generic.List<Skill>>();
		for (int i = 0; i < characters.Count; ++i) {
			queues.Add(new System.Collections.Generic.List<Skill>());
		}

		characterIndex = 0;
		skillIndex = 0;
		targetIndex = 0;
	}

	private void populateCharacters() {
		characters = new System.Collections.Generic.List<Character>();
		foreach (string file in battle.CharacterFiles) {
			characters.Add(GD.Load<Character>(file));
		}
	}

	private void populateSkills() {
		skills = new System.Collections.Generic.List<System.Collections.Generic.List<Skill>>();
		foreach (Character character in characters) {
			System.Collections.Generic.List<Skill> addedSkills = new System.Collections.Generic.List<Skill>();
			foreach (string name in character.SkillNames) {
				addedSkills.Add(battle.getSkillByName(name));
			}
			skills.Add(addedSkills);
		}
	}

	public void doTheThing(InputEventKey input) {
		//Take keyboard input, battle phase
		switch (phase) {
			case "Player":
				
				switch (input.Keycode) {
					case Key.Z:
						phase = "Targeting";
						break;
					case Key.X:
						if (characterIndex > 0) {
							skills.RemoveAt(0);
							skillIndex = 0;
							characterIndex -= 1;
						}
						break;
					case Key.Left:
						if (skillIndex > 0) {
							skillIndex -= 1;
						}
						break;
					case Key.Right:
						if (skillIndex < (skills[characterIndex].Count - 1)) {
							skillIndex += 1;
						}
						break;
				}
				currentSkill = skills[characterIndex].Find(skill => skill.Name == characters[characterIndex].SkillNames[skillIndex]);
				writeText(currentSkill.Name);
				break;
			
			case "Targeting":
				writeText(String.Concat("Currently targeting ", characters[targetIndex].Name));
				switch (input.Keycode) {
					case Key.Z:
						currentSkill.target = characters[targetIndex];
						queues[characterIndex].Insert(0,currentSkill);

						//Output attack choice.
						writeText(String.Concat(characters[characterIndex].Name," is targetting ",
													currentSkill.target.Name," with ",
													currentSkill.Name,"."));

						skillIndex = 0;
						characterIndex += 1;

						//Skip over non-playable characters.
						while (characterIndex < characters.Count && !characters[characterIndex].IsPlayable) {
							characterIndex += 1;
						}
						if (characterIndex >= characters.Count) {
							phase = "Enemy";
						}

						break;
					case Key.X:
						phase = "Player";
						break;
					case Key.Left:
						if (targetIndex > 0) {
							targetIndex -= 1;
						}
						break;
					case Key.Right:
						if (targetIndex < (characters.Count - 1)) {
							targetIndex += 1;
						}	
						break;	
				}
				
				break;

			case "Enemy":
				//Make all enemies choose to attack for now.
				skillIndex = 0;
				characterIndex = 0;
				foreach (Character enemy in characters) {
					if (!enemy.IsPlayable) {
						currentSkill = skills[characterIndex][skillIndex];
						currentSkill.target = characters.Find(character => character.Name == "Gisela");
						queues[characterIndex].Insert(0,currentSkill);
					}
					characterIndex += 1;
				}
				phase =  "Clean Up"; //Will be "Enact" when that gets finished
				break;
			
			case "Enact":
				//Do the actions.

			case "Clean Up":
				//Check for story beat or end of encounter.
				//code

				//Remove last action in queue if needed.
				for (i = 0; i < characters.Count; ++i) {//Output queues.
					//Output queue first.
					text = String.Concat(characters[i].Name, " Queue: ");
					foreach (Skill skill in queues[i]) {
						text = String.Concat(text, skill.Name, " ");
					}
					writeText(text);

					if (queues[i].Count == maxQueueLength) {
						queues[i].RemoveAt(maxQueueLength - 1);
					}
				}

				text = "";
				skillIndex = 0;
				characterIndex = 0;
				targetIndex = 0;
				phase = "Player";
				break;
		}
	}
	
	//Will be updated to output text to the UI.
	private void writeText(string text) {
		GD.Print(text);
	}
	

}
