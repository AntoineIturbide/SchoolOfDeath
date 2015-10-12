using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterWalk {

	/* ATTRIBUTES */

	// Walk state movespeed
	public float _walkSpeed = 1000;

	// Walk acceleration
	public float _acceleration = 0.1f;

	// Walk momentum conservation
	public float _inertia = 0.1f;

	// Curent walk velocity
	[HideInInspector] public Vector2 _velocityInput = Vector3.zero;



	/* METHODS */

	// Recieve input from controller
	public void RecieveInputs(InputSystem inputSystem){
		// Calculate x axis walk velocity
		_velocityInput.x =
			(inputSystem.L_STICK.x == 0)
			? Mathf.MoveTowards(_velocityInput.x,0,_inertia * Time.deltaTime * _walkSpeed)
			:  Mathf.Clamp(_velocityInput.x + (inputSystem.L_STICK.x * Time.deltaTime * _acceleration * _walkSpeed), -_walkSpeed, _walkSpeed);
		// Calculate y axis walk velocity
		_velocityInput.y =
			(inputSystem.L_STICK.y == 0)
			? Mathf.MoveTowards(_velocityInput.y,0,_inertia * Time.deltaTime * _walkSpeed)
			:  Mathf.Clamp(_velocityInput.y + (inputSystem.L_STICK.y * Time.deltaTime * _acceleration * -_walkSpeed), -_walkSpeed, _walkSpeed);
	}

}
