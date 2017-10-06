using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastObjectRotate : MonoBehaviour {

	void Start () 
	{
		transform.rotation = Random.rotation;
		rotation = Random.onUnitSphere;
	}

	Vector3 rotation;
	public float rotationChange = 50;
	void Update () 
	{
		var change = Random.onUnitSphere / rotationChange;
		rotation = (rotation + change).normalized;
		transform.Rotate(rotation);
	}
}
