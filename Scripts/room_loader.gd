extends Area2D

class_name room_loader
@onready var room = get_parent()
@onready var lamps = [] 
var tween

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	tween = create_tween()
	tween.tween_property(room, "modulate:a", 1, 0)

func _on_body_entered(_body: Node2D) -> void:
	for lamp in lamps:
		lamp.show()

func _on_body_exited(_body: Node2D) -> void:
	turn_off()

func turn_off():
	for lamp in lamps:
		lamp.hide()
