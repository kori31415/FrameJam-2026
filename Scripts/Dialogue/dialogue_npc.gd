class_name DialogueKey
extends Node2D

@onready var interactionArea : InteractionArea = $InteractionArea

func _ready():
	pass

func _on_interact (player : Player):
	print("test")
	#player.dialogueController.setDialogue(dialogue)
