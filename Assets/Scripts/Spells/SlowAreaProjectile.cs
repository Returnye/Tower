using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAreaProjectile : Projectile {

	void Start () 
	{
		systems = FindObjectsOfType<HealthSystem>();
	}

	float time;
	bool emitting;
	public float emitDuration;
	public float radius = 25f;
	public float slowPercentage;

	HealthSystem[] systems;
	void Update()
	{
		if (!emitting)
		{
			transform.Translate(transform.forward * projectileSpeed + transform.up * (1 - time), Space.World);
			time += Time.deltaTime;
		}
		else
		{
			foreach (var system in systems)
			{
				if (Vector3.Distance(transform.position, system.transform.position) < radius)
				{
					system.speedVariable = slowPercentage;
				}
				else
				{
					system.speedVariable = 1;
				}
			}
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		emitting = true;
		time = emitDuration;
		//transform.position = new Vector3(transform.position.x, 0, transform.position.y);
		StartCoroutine(EffectAndDestroy());
	}

	public void OnDestroy()
	{
		foreach (var system in systems)
		{
			system.speedVariable = 1;
		}
	}
}
