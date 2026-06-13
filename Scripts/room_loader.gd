extends Area2D

class_name room_loader
@onready var room = get_parent()

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_body_entered(body: Node2D) -> void:
	room.show()
	print(body)

func _on_body_exited(body: Node2D) -> void:
	room.hide()
	print(room)
