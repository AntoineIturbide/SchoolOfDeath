using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainGameSystem : MonoBehaviour {

	/* ATRIBUTES */

	//List of player contollers
	List<InputSystem> _controllerList = new List<InputSystem>();

	//List of characters objects
	List<CharacterSystem> _characterList = new List<CharacterSystem>();

	// [Debug] Test character references
	public InputSystem _debug_mainController;
	public CharacterSystem _debug_mainCharacter;



	/* METHODS */

	// Update the whole game
	void Update(){
		// [Debug] Let the mainCharacter recieve the mainController's inputs
		_debug_mainCharacter.RecieveInputs(_debug_mainController);
	}

}
