using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knockback : Spell {

	public HealthSystem thisSystem;
	void Update () 
	{
		thisSystem = GetComponentInParent<HealthSystem>();
		systems = FindObjectsOfType<HealthSystem>();
		systems = systems.Where(s => s != thisSystem).ToArray();
	}

	public override void Cast()
	{
		StartCoroutine(Delay());
	}

	public float range;
	public HealthSystem[] systems;
	IEnumerator Delay()
	{
		yield return new WaitForSeconds(delayTime);
		while(systems.Any(s => Vector3.Distance(s.transform.position, focus.position) < range - 1))
		{
			foreach(var system in systems)
			{
				var vector = system.transform.position - focus.position;
				vector.y = 0;
				vector = vector.normalized;
				system.transform.position = system.transform.position + vector * Mathf.Clamp(range - Vector3.Distance(focus.position, system.transform.position), 0, range) * 0.1f;
				//system.transform.position = Vector3.MoveTowards(system.transform.position, system.transform.position + vector * range, range - Vector3.Distance(focus.position, system.transform.position) * 0.1f);
			}
			yield return new WaitForEndOfFrame();
		}
	}
	
	Array InRange()
	{
		List<HealthSystem> tempSystems = new List<HealthSystem>();
		foreach(var system in systems)
		{
			if(Vector3.Distance(focus.position, system.transform.position) < range)
			{
				tempSystems.Add(system);
			}
		}
		return tempSystems.ToArray();
	}
}
