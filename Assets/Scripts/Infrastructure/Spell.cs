using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour {

	public string spellName;
	public Transform focus;
	public bool[] pattern = new bool[12];
	public float delayTime;
	public float damage;
	public ParticleSystem chargeEffect;
	public abstract void Cast();
}
