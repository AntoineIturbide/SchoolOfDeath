using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CharacterPhysic  {

	/* ATTRIBUTES */

	// Linked character rigidbody
	[HideInInspector] public Rigidbody _rigidbody;

	// Velocity conserved between frames
	[HideInInspector] public Vector3 _conservedVelocity = Vector3.zero;

	// List of impulses
	public List<Vector3> _impulsesList = new List<Vector3>();

	// List of blinks
	public List<Vector3> _blinksList = new List<Vector3>(); 

	public float _timeAtLastColisionWithGround = 0;
	public float _onGroundAccuracy = 0.1f;


	/* REFERENCES */

	// World's gravity vector
	public Vector3 _gravity {
		get{ return Physics.gravity; }
	}

	// Character's mass
	public float _mass {
		get{ return _rigidbody.mass; }
	}

	// Return if the player is on ground
	public bool _onGround {
		get { return (Time.fixedTime - _timeAtLastColisionWithGround) <= _onGroundAccuracy; }
	}



	/* METHODS */

	// Apply gravity to the conserved velocity
	public void ApplyGravity(){
		// Calculate how to aply gravity based on character's mass, the gravity vector and time
		_conservedVelocity += _mass * _gravity * Time.fixedDeltaTime;
	}

	// Apply jump to the conserved velocity
	public void ApplyJump(CharacterJump jump){
		// Calculate how to aply a jum based on character's mass, the gravity vector and time
		_conservedVelocity += jump._jumpStrengh * -_gravity.normalized;
	}

	// Reset character's applied gravity
	public void ResetGravity(){
		// If the character is going in the same direction as gravity is pushing him to
		if(Vector3.Project(_conservedVelocity,_gravity.normalized).y < 0){
			// Substract the momuntum in that direction
			_conservedVelocity -= Vector3.Project(_conservedVelocity,_gravity.normalized);
		}
	}

	// Return if a contact is connected to the ground
	public bool CheckContactWithGround(ContactPoint contact){
		return Vector3.Project(contact.normal,_gravity.normalized).y > 0.5f;
	}

	// Add an impulse to the physic engine
	void AddImpulse(Vector3 newImpulse) {
		_impulsesList.Add(newImpulse);
	}

	// Add an impulse to the physic engine
	void AddBlink(Vector3 newBlink) {
		_blinksList.Add(newBlink);
	}
}
