extends CharacterBody2D

@onready var _animation_player = $Animations

const tile_size = 16
var move_speed = 0.5
var moving = false
var input_direction

var can_move : bool = true

func _physics_process(delta: float) -> void:
	if not moving:
		input_direction = Vector2.ZERO
		if Input.is_action_pressed("Left"):
			input_direction = Vector2.LEFT
			_animation_player.play("Face_Left")
		elif Input.is_action_pressed("Right"):
			input_direction = Vector2.RIGHT
			_animation_player.play("Face_Right")
		elif Input.is_action_pressed("Up"):
			input_direction = Vector2.UP
			_animation_player.play("Face_Up")
		elif Input.is_action_pressed("Down"):
			input_direction = Vector2.DOWN
			_animation_player.play("Face_Down")
		if can_move:
			move()
	if Input.is_action_just_pressed("Cancel"):
		if move_speed == 0.5:
			move_speed = 0.25
		else:
			move_speed = 0.5

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

func toggle_movement (toggle : bool):
	can_move = toggle
