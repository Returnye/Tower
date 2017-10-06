using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CastingTable : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		spellBook = GetComponentsInChildren<Spell>();
		castNodes = GetComponentsInChildren<CastingObject>();
		activeNodes = new bool[castNodes.Length];
	}

	CastingObject[] castNodes;
	public bool[] activeNodes;
	Spell[] spellBook;
	bool readyToCast = true;
	public ParticleSystem fizzle;
	public void Cast()
	{
		if (readyToCast)
		{
			for (int i = 0; i < activeNodes.Length; ++i)
			{
				activeNodes[i] = castNodes[i].isActive();
				castNodes[i].Clear();
			}

			foreach (var spell in spellBook)
			{
				if (activeNodes.SequenceEqual(spell.pattern))
				{
					StartCoroutine(CastCooldown(spell.delayTime));
					spell.chargeEffect.Play();
					spell.Cast();
					return;
				}
			}
			fizzle.Play();
		}
	}

	IEnumerator CastCooldown(float castDelay)
	{
		readyToCast = false;
		yield return new WaitForSeconds(castDelay);
		readyToCast = true;
	}

	public bool canCast() { return readyToCast; }
}
