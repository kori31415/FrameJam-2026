extends CharacterBody2D

const tile_size = 64
const move_speed = 0.5
var moving = false
var input_direction

func _physics_process(delta: float) -> void:
	input_direction = Vector2.ZERO
	if Input.is_action_just_pressed("Left"):
		input_direction = Vector2.LEFT
	elif Input.is_action_just_pressed("Right"):
		input_direction = Vector2.RIGHT
	elif Input.is_action_just_pressed("Up"):
		input_direction = Vector2.UP
	elif Input.is_action_just_pressed("Down"):
		input_direction = Vector2.DOWN
	move()

func move():
	if input_direction:
		if moving == false:
			moving = true
			var tween = create_tween()
			tween.set_process_mode(Tween.TWEEN_PROCESS_PHYSICS)
			tween.tween_property(self,"position", position + input_direction*tile_size,move_speed)
			tween.tween_callback(movefalse)
	move_and_slide()

func movefalse():
	moving = false
