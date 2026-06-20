using Godot;
using System;

public partial class BattleEngine: Node {
	
	const int maxQueueLength = 3;

	private Battle battle;
	private System.Collections.Generic.List<Character> characters;
	private System.Collections.Generic.List<System.Collections.Generic.List<Skill>> skills;
	private System.Collections.Generic.List<System.Collections.Generic.List<Skill>> queues;

	private int characterIndex;
	private int skillIndex;
	private int targetIndex;
	private int newTarget;
	private string text;
	private string phase;
	private System.Collections.Generic.List<string> storyText;
	private Skill currentSkill;
	private Enemy currentEnemy;

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
		foreach (string name in battle.CharacterNames) {
			if (BattleList.battles[battle.BattleName].playerCharacters.ContainsKey(name)) {
				characters.Add(GD.Load<Character>(BattleList.battles[battle.BattleName].playerCharacters[name]));
			}
			if (battle.enemies.ContainsKey(name)) {
				characters.Add(battle.enemies[name]);
			}
		}
	}

	private void populateSkills() {
		skills = new System.Collections.Generic.List<System.Collections.Generic.List<Skill>>();
		foreach (Character character in characters) {
			System.Collections.Generic.List<Skill> addedSkills = new System.Collections.Generic.List<Skill>();
			foreach (string name in character.SkillNames) {
				addedSkills.Add(battle.getSkillByName(name).clone());
			}
			skills.Add(addedSkills);
		}
	}

	private void incrementTarget(string target) {
		switch (target) {
			case "Self": 
				targetIndex = characterIndex;
				break;
			case "Allies":
				while (!characters[newTarget].IsPlayable && newTarget < (characters.Count - 1)) {
					newTarget += 1;
				}
				if (newTarget == (characters.Count - 1) && !characters[newTarget].IsPlayable) {
					//If it loops through all characters and doesn't find an ally,
					//reset the target so it doesn't change.
					newTarget = targetIndex;
				}
				targetIndex = newTarget;
				break;
			case "Enemies":
				while (characters[newTarget].IsPlayable && newTarget < (characters.Count - 1)) {
					newTarget += 1;
				}
				if (newTarget == (characters.Count - 1)&& characters[newTarget].IsPlayable) {
					//If it loops through all characters and doesn't find an enemy,
					//reset the target so it doesn't change.
					newTarget = targetIndex;
				}
				targetIndex = newTarget;
				break;
		}
	}

	private void incrementTarget() {
		switch (currentSkill.ValidTargets) {
			case "Self": 
				targetIndex = characterIndex;
				break;
			case "Allies":
				while (!characters[newTarget].IsPlayable && newTarget < (characters.Count - 1)) {
					newTarget += 1;
				}
				if (newTarget == (characters.Count - 1) && !characters[newTarget].IsPlayable) {
					//If it loops through all characters and doesn't find an ally,
					//reset the target so it doesn't change.
					newTarget = targetIndex;
				}
				targetIndex = newTarget;
				break;
			case "Enemies":
				while (characters[newTarget].IsPlayable && newTarget < (characters.Count - 1)) {
					newTarget += 1;
				}
				if (newTarget == (characters.Count - 1)&& characters[newTarget].IsPlayable) {
					//If it loops through all characters and doesn't find an enemy,
					//reset the target so it doesn't change.
					newTarget = targetIndex;
				}
				targetIndex = newTarget;
				break;
		}
	}

	private void decrementTarget() {
		newTarget = targetIndex;
		switch (currentSkill.ValidTargets) {
			case "Self": 
				targetIndex = characterIndex;
				break;
			case "Allies":
				while (!characters[newTarget].IsPlayable && newTarget > 0) {
					newTarget -= 1;
				}
				if (newTarget == 0 && !characters[newTarget].IsPlayable) {
					//If it loops through all characters and doesn't find an ally,
					//reset the target so it doesn't change.
					newTarget = targetIndex;
				}
				targetIndex = newTarget;
				break;
			case "Enemies":
				while (characters[newTarget].IsPlayable && newTarget > 0) {
					newTarget -= 1;
				}
				if (newTarget == 0 && characters[newTarget].IsPlayable) {
					//If it loops through all characters and doesn't find an enemy,
					//reset the target so it doesn't change.
					newTarget = targetIndex;
				}
				targetIndex = newTarget;
				break;
		}
	}

	private void getStoryBeat() {
		storyText = battle.progressStory(characters);
		if (storyText.Count > 0) {
			foreach (string storyTextLine in storyText) {
				writeText(storyTextLine);
			};
		}
		
	}

	public void doTheThing(InputEventKey input) {
		//Take keyboard input, battle phase
		switch (phase) {
			case "Player":
				
				switch (input.Keycode) {
					case Key.Z:
						phase = "Targeting";
						targetIndex = 0;

						//Make sure it's targetting the proper character.
						incrementTarget();
						decrementTarget();

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
				writeText(String.Concat("Previously targeting ", characters[targetIndex].Name));
				switch (input.Keycode) {
					case Key.Z:
						currentSkill = currentSkill.clone();
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
						phase = characterIndex >= characters.Count ? "Enemy" : "Player";

						break;
					case Key.X:
						phase = "Player";
						break;
					case Key.Left:
						decrementTarget();
						break;
					case Key.Right:
						incrementTarget();
						break;
				}
				writeText(String.Concat("Currently targeting ", characters[targetIndex].Name));
				
				break;

			case "Enemy":
				skillIndex = 0;
				for(i = 0; i < characters.Count; ++i) {
					if (!characters[i].IsPlayable) {
						currentEnemy = (characters[i] as Enemy);
						queues[i].Insert(0, currentEnemy.chooseSkill(characters, skills[i]));
					}
				}
				characterIndex = 0;
				skillIndex = 0;
				
				phase =  "Enact";
				break;
			
			case "Enact":
				if (input.Keycode == Key.Z) {
					getStoryBeat();
					if (characterIndex < characters.Count) {
						if (skillIndex	 < queues[characterIndex].Count) {
							currentSkill = queues[characterIndex][skillIndex];
							if (text == currentSkill.BeginningText) {
								currentSkill.enactAction(0);
								text = currentSkill.EndingText;
								writeText(text);
								skillIndex += 1;
							} 
							else {
								text = currentSkill.BeginningText;
								writeText(text);
							}
						}
						else {
							characterIndex += 1;
							skillIndex = 0;
						}
					}
					else {
						phase = "Clean Up";
					}
				}
				break;

			case "Clean Up":
				//Check for story beat or end of encounter.
				getStoryBeat();

				//Remove last action in queue if needed.
				for (i = 0; i < characters.Count; ++i) { //Output queues.
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
		
		foreach (System.Collections.Generic.KeyValuePair<string, int> customSkillNumber in currentSkill.customNumbers) {
			if (text.ToLower().Contains(String.Concat("{", customSkillNumber.Key.ToLower(), "}"))) {
				text = text.Replace(String.Concat("{", customSkillNumber.Key.ToLower(), "}"), customSkillNumber.Value.ToString());
			}
		}
		if (text.Contains("{character}")) {
			text = text.Replace("{character}", characters[characterIndex].Name);
		}
		if (text.Contains("{target}")) {
			text = text.Replace("{target}", currentSkill.target.Name);
		}
		GD.Print(text);
	}
	

}
