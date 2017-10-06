using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HomingProjectile : Projectile {

	void Start()
	{
		var systems = FindObjectsOfType<HealthSystem>();
		systems = systems.Where(s => s != GetOrigin()).ToArray();
		target = systems[0].transform;
		foreach(var system in systems)
		{
			if(Vector3.Distance(transform.position, system.transform.position) < Vector3.Distance(transform.position, target.position))
			{
				target = system.transform;
			}
		}
	}

	Transform target;
	float turnTime = 5f;
	void Update()
	{
		transform.Translate(transform.forward * projectileSpeed, Space.World);
		if (turnTime >= 0)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(target.position - transform.position, transform.up), 40f * Time.deltaTime);
			turnTime -= Time.deltaTime;
		}
		else if(turnTime < -25)
		{
			Destroy(gameObject);
		}
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(EffectAndDestroy());
		var health = collision.gameObject.GetComponent<HealthSystem>();
		if (health)
		{
			health.TakeDamage(projectileDamage);
		}
	}
}
