//

using UnityEngine;
using System.Collections;

public class BlinkTeleport : MonoBehaviour {
	
	float maxBlinkLength = 4.0f;

	void Teleport()
	{
		Vector3 teleport = gameObject.transform.position + Camera.main.transform.forward * maxBlinkLength;
		transform.position = teleport;
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Teleport();
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit , 8 ))
			Debug.DrawLine(ray.origin, hit.point);
	}
}
