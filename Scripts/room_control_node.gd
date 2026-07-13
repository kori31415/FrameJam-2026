extends Node2D

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	if len(MusicPlayer.current_song) == 0:
		MusicPlayer.load_song("Unsettling")
	elif MusicPlayer.current_song[3] != "Unsettling":
		MusicPlayer.load_song("Unsettling")
	for scene in globals.seen_cutscenes:
		if scene == null:
			pass
		else:
			scene.disable_cutscene()
