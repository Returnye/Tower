using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	CharacterController controller;
	void Start ()
	{
		controller = GetComponent<CharacterController>();
		Physics.IgnoreCollision(GetComponent<Collider>(), GetComponentInParent<Collider>());
		Physics.IgnoreLayerCollision(8, 9);
	}


	public float moveSpeed = 10f;
	public float gravity = 20f;
	public float jumpSpeed = 8f;

	public Vector3 moveDirection;
	void Update ()
	{
		var falling = moveDirection.y;
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = falling;

		if (controller.isGrounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		else
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}


		moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection * Time.deltaTime);
	}
}
