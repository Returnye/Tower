using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Transform cam;
	public LayerMask layerMask;
	Interactable target;
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(cam.position, cam.forward, out hit, 10f, layerMask))
			{
				Debug.DrawLine(cam.position, hit.point, Color.green);
				target = hit.transform.GetComponent<Interactable>();
				if (target)
				{
					target.Interact();
					//dir = (new Vector3(hit.point.x, target.transform.position.y, hit.point.z) - target.transform.position).normalized;
				}
			}
		}

		if(Input.GetMouseButtonUp(0) && target)
		{
			target.StopInteract();
			target = null;
		}
	}
}
