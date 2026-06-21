extends StaticBody2D


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	self.hide()
	get_parent().get_parent().find_children("", "room_loader")[0].lamps.append(self)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass
