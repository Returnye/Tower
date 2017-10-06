using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingObject : Interactable {

	// Use this for initialization
	void Start ()
	{
		table = GetComponentInParent<CastingTable>();
		active = GetComponent<ParticleSystem>();
	}
	
	void Update ()
	{
	}

	CastingTable table;
	public ParticleSystem activeEffect;
	bool active;
	public override void Interact()
	{
		if (active)
		{
			Clear();
		}
		else if(table.canCast())
		{
			active = true;
			activeEffect.Play();
		}
	}

	public override void StopInteract()
	{

	}

	public bool isActive() { return active; }
	public void Clear()
	{
		active = false;
		activeEffect.Stop();
	}
}
