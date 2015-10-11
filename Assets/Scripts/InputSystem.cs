using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {

	public Vector2 L_STICK {
			get {
			return new Vector2(Input.GetAxis("_xboxController[1].L_STICK.x"),Input.GetAxis("_xboxController[1].L_STICK.y"));
			}
			
	}
	public Vector2 R_STICK {
		get {
			return new Vector2(Input.GetAxis("_xboxController[1].R_STICK.x"),Input.GetAxis("_xboxController[1].R_STICK.y"));
		}
	}

	public bool B, C, D;

	public bool A {
		get {
			return Input.GetKeyDown(KeyCode.Joystick1Button0);
		}
	}

	public void Awake() {
		B = C = D = false;
	}

}