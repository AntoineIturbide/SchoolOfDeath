using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CharacterSystem : MonoBehaviour {

	Vector3 _walkOrder;

	Vector3 _velocity = Vector3.zero;

	Rigidbody _rigidbody;

	void Awake(){
		_rigidbody = GetComponent<Rigidbody>();
	}

	void UpdateVelocity(InputSystem inputSystem){
		Vector3 newVelocity = Vector3.zero;
		newVelocity.x = inputSystem.L_STICK.x;
		newVelocity.z = inputSystem.L_STICK.y;
	}

}
