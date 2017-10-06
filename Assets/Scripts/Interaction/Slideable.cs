using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slideable : Interactable {

	void Start () 
	{
		cam = FindObjectOfType<Camera>().transform;
		maxDistance = Vector3.Distance(bottomTarget.position, topTarget.position);
		percentage = Vector3.Distance(transform.position, bottomTarget.position) / maxDistance;
	}
	
	bool sliding;
	float maxDistance;
	public float percentage;
	Vector3 point;
	Vector3 newPoint;
	public Transform parent;
	public Transform topTarget;
	public Transform bottomTarget;
	float currentHeight;
	void Update() 
	{
		if(sliding)
		{
			Ray ray = new Ray(cam.position, cam.forward);
			float distance = 0;
			var hPlane = new Plane(cam.position - transform.position, parent.position);
			if (hPlane.Raycast(ray, out distance))
			{
				newPoint = ray.GetPoint(distance);
				if (point == Vector3.zero)
				{
					point = newPoint;
				}
			}
			currentHeight = Mathf.Clamp01(currentHeight + Vector3.Distance(Vector3.Project(point, transform.up), Vector3.Project(newPoint, transform.up)) * (Vector3.Dot(transform.up, newPoint - point) > 0? 1 : -1));
			transform.position = Vector3.Slerp(bottomTarget.position, topTarget.position, currentHeight);

			if (hPlane.Raycast(ray, out distance))
			{
				point = ray.GetPoint(distance);
			}

			percentage = Vector3.Distance(transform.position, bottomTarget.position) / maxDistance;
		}
	}
	
	public override void Interact()
	{
		sliding = true;
	}

	public override void StopInteract()
	{
		sliding = false;
		point = Vector3.zero;
	}
}
