using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAOEProjectile : Projectile {

	void Start () 
	{
		pulseInterval = timer / pulses;
		StartCoroutine(DelayDestroy());
	}

	Vector3 offset = new Vector3(0, 6.5f, 0);
	public float timer;
	public int pulses;
	float pulseTimer;
	float pulseInterval;
	void Update () 
	{
		transform.Translate(transform.forward * projectileSpeed, Space.World);

		if(pulseTimer >= pulseInterval)
		{
			var hits = Physics.OverlapCapsule(transform.position + offset, transform.position - offset, 15);
			foreach(var hit in hits)
			{
				var health = hit.GetComponent<HealthSystem>();
				if (health)
				{
					health.TakeDamage(projectileDamage);
				}
			}
			pulseTimer = 0;
		}
		pulseTimer += Time.deltaTime;
	}

	IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(timer);
		Destroy(gameObject);
	}
}
