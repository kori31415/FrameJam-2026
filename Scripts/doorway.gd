extends Area2D

@onready var room = get_parent()
@onready var animation = $AnimatedSprite2D
@onready var light_blocker = $LightOccluder2D
@export var locked = false
#@export var linked_key = 

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.

func _on_body_entered(_body: Node2D) -> void:
	animation.play()
	light_blocker.occluder_light_mask = 0

func _on_body_exited(_body: Node2D) -> void:
	animation.play_backwards()
	light_blocker.occluder_light_mask = 1

func lock_doors():
	if !locked:
		collision_layer = false
		
#func unlock_door():
