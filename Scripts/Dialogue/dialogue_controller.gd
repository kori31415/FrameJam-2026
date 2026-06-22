class_name DialogueController
extends Node

var current_dialogue : Dialogue

@onready var dialogue_screen : Panel = $HUD/DialogueScreen
@onready var name_text = $HUD/DialogueScreen/DialogueBox/BG/Name
@onready var dialogue_text = $HUD/DialogueScreen/DialogueBox/BG/Dialogue

@onready var player : CharacterBody2D = $".."

var visible_chars : float
var current_line : int
var is_cutscene : bool

func _ready ():
	close_screen()	

func set_dialogue(dialogue : Dialogue, cutscene: bool):
	current_dialogue = dialogue
	is_cutscene = cutscene
	
	dialogue_screen.visible = true
	
	current_line = -1
	

func _process (delta : float):
	visible_chars += 30 * delta
	dialogue_text.visible_characters = int(visible_chars)
	
	if not current_dialogue:
		return
	
	if Input.is_action_just_pressed("Interact") || (is_cutscene && current_line == -1):
		if len(current_dialogue.lines) == current_line + 1:
			player.can_move = true
			player.can_interact = true
			close_screen()
		else:
			current_line += 1
			_set_line(current_dialogue.lines[current_line], current_dialogue.char_name[current_line])

func _set_line(line : String, name : String):
	visible_chars = 0
	dialogue_text.visible_characters = 0
	dialogue_text.text = line
	name_text.text = name

func close_screen():
	dialogue_screen.visible = false
	current_dialogue = null
