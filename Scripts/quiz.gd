extends Node2D

@onready var dialog_ui = %DialogUI

static var has_completed_quiz = false
var dialog_index : int = 0
var dialog_lines: Array = []

func _ready() -> void:
	
	if has_completed_quiz:
		queue_free() 
	
	#load dialogue
	dialog_lines = load_dialog("res://Assets/Dialogue/Dialogue 9.json")
	
	#choice selected
	dialog_ui.choice_selected.connect(_on_choice_selected)
	dialog_index = 0
	process_line()

func _input(event: InputEvent): 
	var line = dialog_lines[dialog_index]
	var has_choices = line.has("choice")
	
	#plays next line
	if event.is_action_pressed("next_line") and not has_choices:
		if  dialog_ui.dialog_text.visible_characters > dialog_ui.current_shown_chars:
			dialog_ui.skip_text_animation()
		elif dialog_index < len(dialog_lines) - 1:
			dialog_index += 1
			process_line()
			
	#plays prev lines
	if event.is_action_pressed("prev_line"):
		if dialog_index >= 1 :
			dialog_index -= 1
			process_line()
		
			
	
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
	
func process_line() -> void:
	var line = dialog_lines[dialog_index]
	
	# Check if is goto command
	if line.has("goto"):
		var anchor_pos = get_anchor_pos(line["goto"])
		
		if anchor_pos == -1:
			return
			
		dialog_index = anchor_pos 
		process_line()
		return
	
	#check if Anchor
	if line.has("anchor"):
		dialog_index += 1
		process_line()
		return
		
	if line.has("endQuiz"):
		print("Yoo we ended")
		has_completed_quiz = true
		queue_free()
		return
		
	if line.has("choice"):
		#display choices
		dialog_ui.display_choices(line["choice"])
	else:
		#reads line. 
		dialog_ui.set_dialog(line["Speaker"],line["Text"])

func get_anchor_pos(anchor: String):
	#find Anchor entry with same name
	for i in range(dialog_lines.size()): 
		if dialog_lines[i].has("anchor") and dialog_lines[i]["anchor"] == anchor:
			return i
	#no Anchor is found
	printerr("Error: Could not finde anchor: '" + anchor +"'")
	return -1
	
func _on_choice_selected(anchor: String):
	dialog_index = get_anchor_pos(anchor)
	process_line()
