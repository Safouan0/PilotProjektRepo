
extends Control

#signals 
signal choice_selected

#preload the player choice scene
const ChoiceButtonScene = preload("res://Scenes/player_choice.tscn")

@onready var dialog_text = %DialogText
@onready var speaker_name = %SpeakerName
@onready var text_blib_player = %TextBlibPlayer
@onready var choice_list = %ChoiceList

const ANIMATION_SPEED : int = 30
const NO_SOUND_CHARS : Array = [" ","?","!",":"]

var animate_text : bool = false
var current_shown_chars : int = 0

func _ready():
	choice_list.hide()

func skip_text_animation():
	dialog_text.visible_ratio = 1
	current_shown_chars = dialog_text.visible_characters
	animate_text = false

func display_choices(choices: Array):
	#clear existing buttons
	for child in choice_list.get_children():
		child.queue_free()
		
	#create button for each choice
	for choice in choices:
		var choice_button = ChoiceButtonScene.instantiate()
		choice_button.text = choice["Text"]
		
		#connect button to choice_selected
		choice_button.pressed.connect(_on_choice_button_pressed.bind(choice["goto"]))
		#add button
		choice_list.add_child(choice_button)
	#show the choice list
	choice_list.show()
	

func set_dialog(name: String, dialog: String):
	speaker_name.text = name
	dialog_text.text = dialog
	current_shown_chars = 0
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
	dialog_text.visible_ratio = 0.0
	animate_text = true

func _on_choice_button_pressed(anchor: String):
	choice_selected.emit(anchor)
	choice_list.hide()
