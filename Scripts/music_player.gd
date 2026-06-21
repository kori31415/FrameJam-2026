extends AudioStreamPlayer2D
var playlist = {"Rats":[16.750,97.15,load("res://Music_Files/Rat Scuffle v01.mp3"), "Rats"],
"Belong":[6.747,96.3,load("res://Music_Files/Those Who Belong.mp3"), "Belong"],
"Unsettling":[8.12,159.12,load("res://Music_Files/Unsettling Place v01 Test.mp3"), "Unsettling"],
"Stay":[2.45,92.91,load("res://Music_Files/Stay Here v01.mp3"), "Stay"],
"Pixie":[6.54, 134.49,load("res://Music_Files/ForestPixie_v01.mp3"), "Pixie"],
"Flower":[14.035, 174.813,load("res://Music_Files/My Flower OG Full.mp3"), "Flower"]
}

var current_song = [] 

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(float):
	loop()
	
func load_song(name):
	current_song = playlist[name]
	stream = current_song[2]
	play()

func loop():
	if get_playback_position() >= current_song[1]:
		play(current_song[0])
