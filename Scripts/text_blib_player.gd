extends AudioStreamPlayer

const sounds : Dictionary = {
	"Angel": preload("res://Assets/Sounds/sfx-blipmale.wav")
}

func play_sound():
	stream = sounds["Angel"]
	play()
