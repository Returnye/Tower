using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	public float speedVariable = 1;
	public float health;
	public void TakeDamage(float damage)
	{
		Debug.Log("Hit " + name + " for " + damage);
		health -= damage;
		if(health <= 0)
		{
			Debug.Log("Destroyed");
		}
	}
}
