extends Node2D

@onready var dialog_ui = %DialogUI

var dialog_index : int = 0
const dialog_lines: Array[String] = [
	"NAME: first line of dialogue",
	"NAME: Second line",
	"NAME: Third line"
]

func _ready() -> void:
	dialog_index = 0
	process_line(parse_line(dialog_lines[dialog_index]))

func _input(event: InputEvent): 
	if event.is_action_pressed("next_line"):
		if dialog_index < len(dialog_lines) - 1:
			dialog_index += 1
			process_line(parse_line(dialog_lines[dialog_index]))
	if event.is_action_pressed("prev_line"):
		if dialog_index >= 1 :
			dialog_index -= 1
			process_line(parse_line(dialog_lines[dialog_index]))
	

func parse_line(line: String) -> Dictionary:
	var line_info = line.split(":")

	return {
		"speaker_name": line_info[0],
		"dialogue_line": line_info[1]
	}

func process_line(line_info: Dictionary) -> void:
	dialog_ui.set_dialog(
		line_info["speaker_name"],
		line_info["dialogue_line"]
	)
