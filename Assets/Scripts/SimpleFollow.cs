using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public Transform target;
	void Update () {
		transform.position = target.position;
	}
}
