using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SalvoProjectile : Projectile {
	
	void Start ()
	{
		rotation = transform.rotation.eulerAngles;
		StartCoroutine(DelayDestroy());
	}

	Vector3 rotation;
	public float rotationChange = 50;
	void Update()
	{
		var change = Random.onUnitSphere / rotationChange;
		rotation = (rotation + change).normalized * (projectileSpeed == 0 ? 0 : 1);
		transform.Rotate(rotation);

		transform.Translate(transform.forward * projectileSpeed, Space.World);
	}

	private void OnCollisionEnter(Collision collision)
	{
		StartCoroutine(EffectAndDestroy());
		var explosion = Physics.OverlapSphere(transform.position, 10f);
		foreach (var hit in explosion)
		{
			var health = hit.GetComponent<HealthSystem>();
			if (health)
			{
				health.TakeDamage(projectileDamage);
			}
		}
	}

	public float timeOut;
	IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(timeOut);
		StartCoroutine(EffectAndDestroy());
	}
}
