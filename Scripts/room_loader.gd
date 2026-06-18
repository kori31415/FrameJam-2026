extends Area2D

class_name room_loader
@onready var room = get_parent()
var tween 

## Called when the node enters the scene tree for the first time.
#func _ready() -> void:
	#tween = create_tween()
	#tween.tween_property(room, "modulate:a", 1, 0)
#
## Called every frame. 'delta' is the elapsed time since the previous frame.
#
#func _on_body_entered(_body: Node2D) -> void:
	#tween.kill()
	#tween = create_tween()
	#tween.tween_property(room, "modulate:a", 1, 0)
	#await  tween.finished
	#room.show()
#
#func _on_body_exited(_body: Node2D) -> void:
	#tween.kill()
	#tween = create_tween()
	#tween.tween_property(room, "modulate:a", 0, 1)
	#await  tween.finished
