using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	public ParticleSystem projectileEffect;
	public GameObject model;

	public float projectileSpeed;
	public float projectileDamage;
	HealthSystem origin;
	public void SetVariables(float speed, float damage, HealthSystem parent)
	{
		projectileSpeed = speed;
		projectileDamage = damage;
		origin = parent;
	}

	public HealthSystem GetOrigin() { return origin; }

	public IEnumerator EffectAndDestroy()
	{
		GetComponent<Collider>().enabled = false;
		model.SetActive(false);
		projectileSpeed = 0;
		projectileEffect.Play();
		yield return new WaitForSeconds(projectileEffect.main.duration);
		Destroy(gameObject);
	}
}
