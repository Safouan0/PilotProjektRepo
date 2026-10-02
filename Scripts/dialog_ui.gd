
extends Control

@onready var dialog_text = %DialogText
@onready var speaker_name = %SpeakerName

const ANIMATION_SPEED : int = 30
var animate_text : bool = false
var current_shown_chars : int = 0

func set_dialog(name: String, dialog: String):
	speaker_name.text = name
	dialog_text.text = dialog
"""
func change_line(line: string):
	current_shown_chars = 0 
	dialog_line.text = line 
	animate_text = true
"""
