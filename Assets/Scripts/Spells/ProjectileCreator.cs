using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCreator : Spell {

	public GameObject projectile;
	public float projectileSpeed;
	//public ParticleSystem explosion;
	public override void Cast()
	{
		StartCoroutine(DelayProjectile());
	}

	IEnumerator DelayProjectile()
	{
		yield return new WaitForSeconds(delayTime);
		var proj = Instantiate(projectile, focus.position, focus.rotation).GetComponent<Projectile>();
		proj.SetVariables(projectileSpeed, damage, GetComponentInParent<HealthSystem>());
	}
}
