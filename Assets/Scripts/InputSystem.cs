using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {

	public Vector2 L_STICK {
			get {
			return new Vector2(Input.GetAxis("XBOX_L_STICK_X"),Input.GetAxis("XBOX_L_STICK_Y"));
			}
			
	}
	public Vector2 R_STICK {
		get {
		return new Vector2(Input.GetAxis("XBOX_L_STICK_X"),Input.GetAxis("XBOX_L_STICK_Y"));
		}
	}

	public bool A, B, C, D;

	public void Awake() {
		A = B = C = D = false;
	}

	public void UpdateCharacter(CharacterSystem targetCharacterSystem) {
		
	}

}