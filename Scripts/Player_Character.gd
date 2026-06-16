extends CharacterBody2D

@onready var _animation_player = $Animations
@onready var ray_cast = $RayCast2D

const tile_size = 16
var ray_length = tile_size
var move_speed = 0.3
var moving = false
var input_direction

var can_move : bool = true

func _physics_process(_delta: float) -> void:
	if not moving:
		input_direction = Vector2.ZERO
		if Input.is_action_pressed("Left"):
			input_direction = Vector2.LEFT
			ray_cast.target_position = input_direction * ray_length
			_animation_player.play("Face_Left")
		elif Input.is_action_pressed("Right"):
			input_direction = Vector2.RIGHT
			ray_cast.target_position = input_direction * ray_length
			_animation_player.play("Face_Right")
		elif Input.is_action_pressed("Up"):
			input_direction = Vector2.UP
			ray_cast.target_position = input_direction * ray_length
			_animation_player.play("Face_Up")
		elif Input.is_action_pressed("Down"):
			input_direction = Vector2.DOWN
			ray_cast.target_position = input_direction * ray_length
			_animation_player.play("Face_Down")
	ray_cast.force_raycast_update()
	if can_move && !ray_cast.is_colliding():
		move()
	if Input.is_action_just_pressed("Cancel"):
		if move_speed == 0.5:
			move_speed = 0.25
		else:
			move_speed = 0.5

func move():
	if input_direction != Vector2.ZERO:
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
