using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour {

	void Start () 
	{
		
	}
	public HealthSystem system;
	public float speed;
	void Update () 
	{
		transform.Translate(transform.right * speed * system.speedVariable * Time.deltaTime, Space.World);
	}
}
