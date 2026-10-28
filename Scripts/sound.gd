extends AudioStreamPlayer

const sounds : Dictionary = {
	"Angel": preload("res://Assets/Sounds/sfx-blipmale.wav"),
	"Button": preload("res://Assets/Sounds/sfx-blipfemale.wav")
}
func _ready() -> void:
	play_sound("Button")

func play_sound(name):
	stream = sounds[name]
	play()
