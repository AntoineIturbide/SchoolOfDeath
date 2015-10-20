using UnityEngine;
using System.Collections;

public class AbilitySystem : MonoBehaviour {

	// Character owner this ability
	[HideInInspector]
	public CharacterSystem _character;

	public enum LinkedButton {
		NONE,
		L_TRIGGER,
		R_TRIGGER,
		L_BUMPER,
		R_BUMPER,
		A,
		B,
		X,
		Y
	}

	public LinkedButton _linkedButton;

	// Called when the player start pressing the attached button
	void OnButtonPress() {
		
	}

	// Called when the player is pressing the attached button
	void OnButtonMaintained() {

	}

	// Called when the player stop pressing the attached button
	void OnButtonReleased() {

	}

}
