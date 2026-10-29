extends AudioStreamPlayer

const sounds : Dictionary = {
	"Button": preload("res://Assets/Sounds/ButtonPress.mp3")
}

func play_sound(name):
	stream = sounds[name]
	play()
