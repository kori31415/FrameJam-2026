class_name	Player
extends CharacterBody2D

@onready var _animation_player = $Animations
@onready var wall_ray_cast = $Wall_Collison_Cast
@onready var interactable_ray_cast = $Interactable_Cast
@onready var dialogue_controller : DialogueController = $DialogueController

const tile_size = 16
var ray_length = tile_size
var move_speed = 0.3
var moving = false
var input_direction

var can_interact : bool = true
var can_move : bool = true

func _physics_process(_delta: float) -> void:
	if not moving && can_move:
		input_direction = Vector2.ZERO
		if Input.is_action_pressed("Left"):
			input_direction = Vector2.LEFT
			adjust_casts()
			_animation_player.play("Face_Left")
		elif Input.is_action_pressed("Right"):
			input_direction = Vector2.RIGHT
			adjust_casts()
			_animation_player.play("Face_Right")
		elif Input.is_action_pressed("Up"):
			input_direction = Vector2.UP
			adjust_casts()
			_animation_player.play("Face_Up")
		elif Input.is_action_pressed("Down"):
			input_direction = Vector2.DOWN
			adjust_casts()
			_animation_player.play("Face_Down")
		elif Input.is_action_just_pressed("Interact") && interactable_ray_cast.is_colliding() && can_interact:
			dialouge_handler()
			
	if can_move && !wall_ray_cast.is_colliding():
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
	
func adjust_casts():
	wall_ray_cast.target_position = input_direction * ray_length
	wall_ray_cast.force_raycast_update()
	interactable_ray_cast.target_position = input_direction * ray_length
	interactable_ray_cast.force_raycast_update()

func dialouge_handler():
	can_move = false	
	can_interact = false
	var collider = interactable_ray_cast.get_collider()
	dialogue_controller.set_dialogue(collider.dialogue)
	if collider.item:
		collider.get_parent().queue_free()
