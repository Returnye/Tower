using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDriver : MonoBehaviour {

	void Start () 
	{
		castNodes = GetComponentsInChildren<CastingObject>();
		castingTable = GetComponentInChildren<CastingTable>();
	}

	public Transform player;
	void Update () 
	{
		MoveToPlayer();
		Aim();
		if(timer < 0)
		{
			Cast();
			timer = 15f;
		}
		timer -= Time.deltaTime;
	}

	public float distance;
	Vector3 location;
	public Transform steeringTarget;
	void MoveToPlayer()
	{
		var cast = Physics.BoxCast(transform.position, new Vector3(5, 5, 5), steeringTarget.forward, transform.rotation, Vector3.Distance(steeringTarget.position, location));
		if (Vector3.Distance(location, player.position) > distance * 1.3f || cast || Vector3.Distance(location, steeringTarget.position) < 1) //Physics.Linecast(transform.position + steeringTarget.forward * 4, location)
		{
			var loc = Random.insideUnitCircle.normalized;
			location = player.position + new Vector3(loc.x, 0, loc.y) * distance;
			location.y = steeringTarget.position.y;
			Debug.DrawLine(location, location + Vector3.up * 100, Color.red, 2f);
		}
		steeringTarget.LookAt(location);
	}

	public Transform aiming;
	void Aim()
	{
		var direction = Vector3.Cross(transform.forward, player.position - transform.position);
		var magnitude = Mathf.Clamp(Vector3.Angle(transform.forward, player.position - transform.position) / 10, 1, 18);
		aiming.Rotate(Vector3.up, ((direction.y > 0) ? 1 : -1) * magnitude, Space.Self);
	}

	CastingTable castingTable;
	CastingObject[] castNodes;
	public bool[] thisSpell;
	float timer = 15f;
	void Cast()
	{
		for(int i = 0; i < castNodes.Length; ++i)
		{
			if(thisSpell[i])
			{
				castNodes[i].Interact();
			}
		}
		castingTable.Cast();
	}
}
