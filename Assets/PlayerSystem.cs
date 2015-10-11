using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InputSystem))]

public class PlayerSystem : MonoBehaviour {

	public InputSystem _inputSystem;

	// Use this for initialization
	void Awake () {
		_inputSystem = this.gameObject.GetComponent<InputSystem>() as InputSystem;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
