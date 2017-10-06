using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpell : Spell {

	public override void Cast()
	{
		StartCoroutine(Wait());
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(5);
		Debug.Log("Spell cast!");
	}
}
