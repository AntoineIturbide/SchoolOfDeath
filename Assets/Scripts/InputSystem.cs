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

	public bool A, B, C, D;

	public void Awake() {
		A = B = C = D = false;
	}

}