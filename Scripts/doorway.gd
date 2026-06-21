extends StaticBody2D

@onready var room = get_parent()
@onready var animation = $AnimatedSprite2D
@onready var light_blocker = $LightOccluder2D
@export var locked = false
@export var connected_key = ""
#@export var linked_key = 

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	unlock_door()

# Called every frame. 'delta' is the elapsed time since the previous frame.

func _on_body_entered(_body: Node2D) -> void:
	animation.play()
	light_blocker.occluder_light_mask = 0

func lock_doors():
	if !locked:
		collision_layer = false
		
func unlock_door():
	if connected_key in globals.collected_keys:
		collision_layer = false
		animation.play()
		light_blocker.occluder_light_mask = 0
