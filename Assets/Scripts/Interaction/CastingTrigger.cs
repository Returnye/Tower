using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingTrigger : Interactable {

	public CastingTable table;
	void Start () 
	{
		//table = GetComponent<CastingTable>();
	}

	public override void Interact()
	{
		table.Cast();
	}

	public override void StopInteract()
	{
		
	}
}
