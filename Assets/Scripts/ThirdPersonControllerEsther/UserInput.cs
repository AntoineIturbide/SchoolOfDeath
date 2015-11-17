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

	//Power 1
	public GameObject particlePower1;

	int count;

	GameObject mySpawn;

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
		//aim = Input.GetAxis ("_xboxController[1].Triggers");

		/*if (Input.GetAxis ("_xboxController[1].Triggers") < 0) {
			aim = true;
		}*/

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
		bool walkToggle = Input.GetKey (KeyCode.LeftShift) /*|| aim*/;

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

		//if (aim == true) {
		Vector3 origin = Camera.main.transform.position;
		Vector3 direction = Camera.main.transform.forward;
		if (Physics.Raycast (origin, direction, out lastRaycastHit, range)) {
			if (lastRaycastHit.collider.gameObject.tag == "Ennemy") {
				Debug.Log ("je te tiens");
				aim = true;
				//cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 0.5f;

				if (Input.GetAxis ("_xboxController[1].Triggers") > 0 && count < 1) {
					count ++;
					mySpawn = Instantiate (particlePower1, new Vector3 (lastRaycastHit.collider.transform.position.x, lastRaycastHit.collider.transform.position.y + 3.5f, lastRaycastHit.collider.transform.position.z), Quaternion.identity) as GameObject;
					StartCoroutine (timePower1 ());
				}
				/*if (Input.GetAxis ("_xboxController[1].Triggers") == 0) {
					count = 0;
				}*/
			} 
			if (lastRaycastHit.collider.gameObject.tag != "Ennemy") {
				aim = false;
				cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 1.5f;
			}
		} else {
			aim = false;
			cameraContainer.GetComponent<CameraSysthemFreeCameraLoopEstherV2> ().turnSpeed = 1.5f;
		}
	}

	IEnumerator timePower1 ()
	{
		
		yield return new WaitForSeconds (3);
		Destroy (mySpawn);
		count = 0;
	}
}