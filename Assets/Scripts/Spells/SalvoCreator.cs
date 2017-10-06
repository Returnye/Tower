using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvoCreator : Spell {

	public GameObject projectile;
	public float projectileSpeed;
	public int salvoCount;
	float count;
	public float interval;
	public override void Cast()
	{
		count = salvoCount;
		StartCoroutine(DelayProjectile());
	}

	IEnumerator DelayProjectile()
	{
		yield return new WaitForSeconds(delayTime);
		StartCoroutine(DelaySalvo());
	}

	IEnumerator DelaySalvo()
	{
		yield return new WaitForSeconds(interval);
		var proj = Instantiate(projectile, focus.position, focus.rotation).GetComponent<Projectile>();
		proj.SetVariables(projectileSpeed, damage, GetComponentInParent<HealthSystem>());
		count -= 1;
		if(count > 0)
		{
			StartCoroutine(DelaySalvo());
		}
	}
}
