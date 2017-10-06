using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEProjectile : Projectile {

	void Start () 
	{
		
	}

	float time;
	void Update () 
	{
		transform.Translate((transform.forward + transform.up * (1 - time)) * projectileSpeed, Space.World);
		time += Time.deltaTime;
	}

	private void OnCollisionEnter(Collision collision)
	{
		//projectileEffect.transform.position = transform.position;
		//projectileEffect.Play();
		StartCoroutine(EffectAndDestroy());
		var explosion = Physics.OverlapSphere(transform.position, 10f);
		foreach(var hit in explosion)
		{
			var health = hit.GetComponent<HealthSystem>();
			if (health)
			{
				health.TakeDamage(projectileDamage);
			}
		}
		//Destroy(gameObject);
	}
}
