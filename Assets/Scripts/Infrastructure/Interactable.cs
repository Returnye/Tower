using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

	public Transform cam;
	public abstract void Interact();
	public abstract void StopInteract();
}
