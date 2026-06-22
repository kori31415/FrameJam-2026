extends StaticBody2D
class_name InteractionArea

@export var dialogue : Dialogue
@export var item: bool
@export var key_name: String
@export var is_key: bool
@export var is_cutscene: bool
@export var is_disabled: bool

var interact : Callable = func():
	pass

func add_key_to_inventory():
	globals.collected_keys.append(key_name)

func disable_cutscene():
	is_disabled = true
