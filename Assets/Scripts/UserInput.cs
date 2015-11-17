using UnityEngine;
using System.Collections;


public class UserInput : MonoBehaviour
{

	public bool walkByDefault = false;

	private CharMove character;
	private Transform cam;
	private Vector3 camForward;
	private Vector3 move;

	//Camera
	//float cameraForward;
	public bool aim;
	public float aimingWeight;
	//float cameraOffSetNormal;
	//float cameraOffsetAiming;
	//float cameraSpeedOffset;

	//Aiming Assist
	private RaycastHit lastRaycastHit;
	
	[Tooltip("Range of the Raycast = how far you can choose to teleport")]
	public float
		range = 10.0f;

	public GameObject cameraContainer;

	void Start ()
	{

		cameraContainer = GameObject.Find ("Camera");

		if (Camera.main != null) {
			cam = Camera.main.transform;
		}

		character = GetComponent<CharMove> ();
	}

	void LateUpdate ()
	{
		aim = Input.GetKey (KeyCode.Joystick1Button0);
		
		aimingWeight = Mathf.MoveTowards (aimingWeight, (aim) ? 1.0f : 0.0f, Time.deltaTime * 5);
		
		Vector3 normalState = new Vector3 (0, 0, -2f);
		Vector3 aimingState = new Vector3 (0.25f, 0, -0.5f);
		
		Vector3 pos = Vector3.Lerp (normalState, aimingState, aimingWeight);
		
		cam.transform.localPosition = pos;
	}

	void FixedUpdate ()
	{

		float horizontal = Input.GetAxis ("_xboxController[1].L_STICK.x");
		float vertical = Input.GetAxis ("_xboxController[1].L_STICK.y");


		if (cam != null) {
			camForward = Vector3.Scale (cam.forward, new Vector3 (1, 0, 1)).normalized;
			move = -vertical * camForward + horizontal * cam.right;
		} else {
			move = -vertical * Vector3.forward + horizontal * Vector3.right;
		}

		if (move.magnitude > 1)
			move.Normalize ();

		//running shift disabled when aimming
		bool walkToggle = Input.GetKey (KeyCode.LeftShift) || aim;

		float walkMultiplier = 1;

		if (walkByDefault) {
			if (walkToggle) {
				walkMultiplier = 1;
			} else {
				walkMultiplier = 0.5f;
			}
		} else {
			if (walkToggle) {
				walkMultiplier = 0.5f;
			} else {
				walkMultiplier = 1;
			}
		}

		move *= walkMultiplier;
		character.Move (move);

		if (aim == true) {
			Vector3 origin = Camera.main.transform.position;
			Vector3 direction = Camera.main.transform.forward;
			if (Physics.Raycast (origin, direction, out lastRaycastHit, range)) {
				if (lastRaycastHit.collider.gameObject.tag == "Ennemy") {
					Debug.Log ("je te tiens");
					cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 0.2f;
				} 
				if (lastRaycastHit.collider.gameObject.tag != "Ennemy") {
					cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 1.5f;
				}
			} else {
				cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 1.5f;
			}
		} else {
			cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 1.5f;
		}
	}
}