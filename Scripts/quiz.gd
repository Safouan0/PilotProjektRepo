extends Node2D

@onready var dialog_ui = %DialogUI

var dialog_index : int = 0
var dialog_lines: Array = []

func _ready() -> void:
	#load dialogue
	dialog_lines = load_dialog("res://Assets/Dialogue/Dialogue.json")
	
	dialog_index = 0
	process_line(dialog_lines[dialog_index])

func _input(event: InputEvent): 
	#plays next line
	if event.is_action_pressed("next_line"):
		if dialog_index < len(dialog_lines) - 1:
			dialog_index += 1
			process_line(dialog_lines[dialog_index])
	#plays prev lines
	if event.is_action_pressed("prev_line"):
		if dialog_index >= 1 :
			dialog_index -= 1
			process_line(dialog_lines[dialog_index])
	
func load_dialog(file_path):
	#check if exist
	if not FileAccess.file_exists(file_path):
		printerr("Error: The file you're trying to access does not exist ", file_path)
		return null 
	
	#open file
	var file = FileAccess.open(file_path, FileAccess.READ)
	if file == null:
		printerr("Error: The file you're trying to access is empty ", file_path)
		return null
	#read content
	var content = file.get_as_text()
	
	#parse .json
	var json_content = JSON.parse_string(content)
	
	#check if file access succesful
	if json_content == null:
		printerr("Error: Failed to parse .JSON file", file_path)
		return null
	return json_content
	
func process_line(line_info: Dictionary) -> void:
	#loads dict with dialog_index nr. 
	dialog_ui.set_dialog(
		line_info["Speaker"],
		line_info["Text"]
	)
