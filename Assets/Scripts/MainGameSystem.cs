using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameSystem : MonoBehaviour {

	//List of player contollers
	List<InputSystem> _controllerList = new List<InputSystem>();

	//List of characters objects
	List<CharacterSystem> _characterList = new List<CharacterSystem>();

	public InputSystem _debug_mainController;
	public CharacterSystem _debug_mainCharacter;

	void Update(){
		// Update mainCharacter with mainController's inputs
		_debug_mainCharacter.RecieveInputs(_debug_mainController);
	}

}
