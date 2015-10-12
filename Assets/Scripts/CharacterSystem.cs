using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class CharacterSystem : MonoBehaviour {

	// [Debgug] Character's rotation speed
	float _debug_rotationSpeed = 200;

	// [Debug] If set to false, allow the character to ignore gravity
	public bool _debug_useGravity = true;



	/* ATTRIBUTES */

	// Character linked transform
	Transform _transform;

	// Character walking system
	public CharacterWalk _walk;

	// Character jumping system
	public CharacterJump _jump;

	// Character physics system
	[HideInInspector]
	public CharacterPhysic _physic;



	/* METHODS */

	void Awake(){
		// Set the character's transform reference
		_transform = this.gameObject.transform;

		// Set the character's rigidbody reference
		_physic._rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}

	public void RecieveInputs(InputSystem inputSystem){
		// Calculate walk velocity from inputs
		_walk.RecieveInputs(inputSystem);

		// If player use jump button and is on ground
		if(inputSystem.A && _physic._onGround){
			// Reset gravity
			_physic.ResetGravity();
			// Apply jump impultion to conserved velocity
			_physic.ApplyJump(_jump);
		}

		// [Debug] Character rotation
		Quaternion newRotation = _transform.localRotation;
		newRotation *= Quaternion.AngleAxis(Time.deltaTime * inputSystem.R_STICK.x * _debug_rotationSpeed, Vector3.up);
		_transform.localRotation = newRotation;

	}



	/* PHYSIC */

	void FixedUpdate() {
		// Apply gravity to the conserved velocity
		// [Debug] Can be desactivated with the _debug_useGravity boolean
		if(_debug_useGravity) _physic.ApplyGravity();

		// Create new velocity based on the conserved velocity
		Vector3 newVelocity = _physic._conservedVelocity;

		// Add character input's velocity
		newVelocity += _walk._velocityInput.x * Time.fixedDeltaTime * _transform.right;
		newVelocity += _walk._velocityInput.y * Time.fixedDeltaTime * _transform.forward;

		// Apply new velocity
		_physic._rigidbody.velocity = newVelocity;
	}

	void OnCollisionEnter(Collision collision){
		// Set last collision (used to detect if on ground)
		_physic._lastCollision = collision;

		// For each contact point,
		foreach (ContactPoint contact in collision.contacts) {
			// If there is contact with the ground
			if(_physic.CheckContactWithGround(contact)){
				// Reset gravity
				_physic.ResetGravity();
			}
		}
	}

	void OnCollisionStay(Collision collision){
		// Set last collision (used to detect if on ground)
		_physic._lastCollision = collision;

		// For each contact point,
		foreach (ContactPoint contact in collision.contacts) {
			// If there is contact with the ground
			if(_physic.CheckContactWithGround(contact)){
				// Reset gravity
				_physic.ResetGravity();
			}
		}
	}

	void OnCollisionExit(Collision collision){
		// Set last collision (used to detect if on ground)
		_physic._lastCollision = collision;
	}

}
