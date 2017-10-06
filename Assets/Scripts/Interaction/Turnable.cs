using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnable : Interactable {

	// Use this for initialization
	void Start ()
	{
		cam = FindObjectOfType<Camera>().transform;
	}

	bool turning;
	public float turnRate;
	void Update ()
	{
		if(turning)
		{
			Ray ray = new Ray(cam.position, cam.forward);
			Plane hPlane = new Plane(transform.up, transform.position);
			float distance = 0;
			if (hPlane.Raycast(ray, out distance))
			{
				newDir = (ray.GetPoint(distance) - transform.position).normalized;
				if(dir == Vector3.zero)
				{
					dir = newDir;
				}
			}

			var angle = Vector3.Angle(dir, newDir);
			transform.RotateAround(transform.position, transform.up, (Vector3.Cross(dir, newDir).y > 0 ? angle : -angle) * turnRate);

			if (hPlane.Raycast(ray, out distance))
			{
				dir = (ray.GetPoint(distance) - transform.position).normalized;
			}

			Debug.DrawLine(transform.position, transform.position + dir * 10, Color.red);
			Debug.DrawLine(transform.position, transform.position + newDir * 10, Color.green);
		}
	}

	Vector3 dir;
	Vector3 newDir;
	public override void Interact()
	{
		turning = true;
	}

	public override void StopInteract()
	{
		turning = false;
		dir = Vector3.zero;
	}
}
