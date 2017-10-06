using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		targetAngle = aiming.localRotation.eulerAngles.y;
	}

	public HealthSystem debuff;
	public Slideable speedModifier;
	public Transform aiming;
	public Transform steering;

	public float speed;

	public float turnSensitivity;
	public float turnTime;

	float oldAim;
	float targetAngle;
	float currentVelocity;
	void Update ()
	{
		var newAim = aiming.localRotation.eulerAngles.y;

		//transform.RotateAround(steering.position, Vector3.up, Mathf.DeltaAngle(oldAim, newAim));
		targetAngle += Mathf.DeltaAngle(oldAim, newAim) * turnSensitivity;
		var newAngle = Mathf.SmoothDampAngle(transform.rotation.eulerAngles.y, targetAngle, ref currentVelocity, turnTime);

		var rot = transform.rotation.eulerAngles;
		rot.y = newAngle;
		transform.rotation = Quaternion.Euler(rot);

		transform.Translate(steering.forward * speed * speedModifier.percentage * debuff.speedVariable * Time.deltaTime, Space.World);

		oldAim = newAim;
	}
}
