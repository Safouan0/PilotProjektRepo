
extends Control

@onready var dialog_text = %DialogText
@onready var speaker_name = %SpeakerName
@onready var text_blib_player = %TextBlibPlayer

const ANIMATION_SPEED : int = 30
const NO_SOUND_CHARS : Array = [" ","?","!",":"]

var animate_text : bool = false
var current_shown_chars : int = 0

func set_dialog(name: String, dialog: String):
	speaker_name.text = name
	dialog_text.text = dialog
	dialog_text.visible_ratio = 0.0
	animate_text = true

func _process(delta):
	if animate_text:
		if dialog_text.visible_ratio < 1:
			dialog_text.visible_ratio += (1.0/dialog_text.text.length())*(ANIMATION_SPEED * delta)
			if dialog_text.visible_characters > current_shown_chars:
				current_shown_chars = dialog_text.visible_characters
				var last_char = dialog_text.text[current_shown_chars-1]
				if last_char not in NO_SOUND_CHARS:
					text_blib_player.play_sound()
		else:
			animate_text = false 
		
		
func change_line(line: String):
	current_shown_chars = 0 
	dialog_text.text = line 
	animate_text = true
