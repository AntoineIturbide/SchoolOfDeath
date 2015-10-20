//CONCEPT: Le joueur se teleport vers l'objet qu'il regarde quand on Input click droit (a changer pour un input manette)
//Pourrait etre un teleport interessant

using UnityEngine;
using System.Collections;

public class lookAtTeleport : MonoBehaviour {

	private RaycastHit lastRaycastHit;

	[Tooltip("Range of the Raycast = how far you can choose to teleport")]
	public float range = 10.0f;

	// Use this for initialization
	void Start () {
		//rend la souris invisible
		Cursor.visible = false;
	}

	//Detection de l'objet par raycast
	private GameObject GetLookedAtObject()
	{
		Vector3 origin = transform.position;
		Vector3 direction = Camera.main.transform.forward;
		if (Physics.Raycast (origin, direction, out lastRaycastHit, range)) 
		{
			return lastRaycastHit.collider.gameObject;
		} 
		else 
		{
			return null;
		}
	}

	//Teleportation vers l'objet
	private void TeleportToLookAt()
	{
		transform.position = lastRaycastHit.point + lastRaycastHit.normal * 2;
	}

	// Update is called once per frame
	void Update () {
		//ICI changer le input mouse par celui d'une manette
		if (Input.GetMouseButtonDown (0)) 
		{
			if(GetLookedAtObject() != null)
			{
				TeleportToLookAt();
			}
		}
	}
}
