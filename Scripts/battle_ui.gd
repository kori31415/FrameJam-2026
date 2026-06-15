extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	$HBoxContainer/Attack.grab_focus.call_deferred()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_attack_pressed() -> void:
	#print("Attack, add attack to queue")
	pass

func _on_defend_pressed() -> void:
	#print("Defend, add defense to queue")
	pass

func _on_skills_pressed() -> void:
	#print("Open Skill Menu")
	pass
