using UnityEngine;
using System.Collections;

public class CameraSystem : MonoBehaviour {

	public CharacterSystem _debug_targetCharacter;

	public Vector3 _velocityInput;
	public float _rotationSpeed;
	public float _rotationAcceleration;
	public float _rotationInertia;

	public bool _reflectY = false;

	// Use this for initialization
	void Start () {
		transform.parent = _debug_targetCharacter.transform;
	}

	void Update() {
		transform.RotateAround(_debug_targetCharacter.transform.position,_debug_targetCharacter.transform.right, _reflectY ? _velocityInput.y : -_velocityInput.y);
	}

	public void RecieveInputs(InputSystem inputSystem){
		// Calculate x axis walk velocity
		_velocityInput.x =
			(inputSystem.R_STICK.x == 0)
			? Mathf.MoveTowards(_velocityInput.x,0,_rotationInertia * Time.deltaTime * _rotationSpeed)
			:  Mathf.Clamp(_velocityInput.x + (inputSystem.R_STICK.x * Time.deltaTime * _rotationAcceleration * _rotationSpeed), -_rotationSpeed, _rotationSpeed);
		// Calculate y axis walk velocity
		_velocityInput.y =
			(inputSystem.R_STICK.y == 0)
			? Mathf.MoveTowards(_velocityInput.y,0,_rotationInertia * Time.deltaTime * _rotationSpeed)
			:  Mathf.Clamp(_velocityInput.y + (inputSystem.R_STICK.y * Time.deltaTime * _rotationAcceleration * -_rotationSpeed), -_rotationSpeed, _rotationSpeed);
	}
}
