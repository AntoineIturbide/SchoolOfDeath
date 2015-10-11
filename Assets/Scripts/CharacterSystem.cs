using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class CharacterSystem : MonoBehaviour {

	float _walkSpeed = 2;
	float _rotationSpeed = 2;

	Vector3 _velocity = Vector3.zero;
	Vector3 _rotationVelocity = Vector3.zero;

	Transform _transform;
	Rigidbody _rigidbody;

	void Awake(){
		_transform = this.gameObject.transform;
		_rigidbody = this.gameObject.GetComponent<Rigidbody>();
	}

	public void RecieveInputs(InputSystem inputSystem){
		// Calculate newVelocity
		Vector3 newVelocity = Vector3.zero;
		newVelocity += inputSystem.L_STICK.x * _transform.right * _walkSpeed;
		newVelocity += inputSystem.L_STICK.y * -_transform.forward * _walkSpeed;
		// Apply newNelocity
		_rigidbody.velocity = newVelocity;

		// Rotate character (and camera)
		Vector3 newRotationVelocity = Vector3.zero;
		newRotationVelocity += Vector3.up * inputSystem.R_STICK.x * _rotationSpeed;
		newRotationVelocity += Vector3.right * inputSystem.R_STICK.y * _rotationSpeed;
		newRotationVelocity.z = 0;

		/*
		Quaternion newRotation = _transform.localRotation.eulerAngles;
		newRotation *= Quaternion.AngleAxis(inputSystem.R_STICK.x * _rotationSpeed, Vector3.up);
		newRotation *= Quaternion.AngleAxis(inputSystem.R_STICK.y * _rotationSpeed, _transform.right);
		newRotation.LookRotation(Vector3.up * inputSystem.R_STICK.x * _rotationSpeed, _transform.right * inputSystem.R_STICK.y * _rotationSpeed);
		_transform.localRotation = newRotation;
		
		Vector3 newRotation = _transform.localRotation.eulerAngles;
		newRotation = newRotation + Quaternion.Euler(inputSystem.R_STICK.x * _rotationSpeed * Vector3.up);
		_transform.localRotation = Quaternion.Euler(newRotation);
		*/

		Quaternion newRotation = _transform.localRotation;
		newRotation *= Quaternion.AngleAxis(inputSystem.R_STICK.x * _rotationSpeed, Vector3.up);
		_transform.localRotation = newRotation;

	}

}
