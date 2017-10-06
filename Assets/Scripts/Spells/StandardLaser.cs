using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardLaser : Spell {
	
	public float range;
	//public ParticleSystem charge;
	public ParticleSystem laser;
	public override void Cast()
	{
		StartCoroutine(DelayLaser());
	}

	IEnumerator DelayLaser()
	{
		//charge.Play();
		yield return new WaitForSeconds(delayTime);
		laser.Play();
		RaycastHit hit;
		if(Physics.SphereCast(focus.position, 2f, focus.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			var target = hit.transform.GetComponent<HealthSystem>();
			if(target)
			{
				target.TakeDamage(damage);
			}
		}
	}
}
